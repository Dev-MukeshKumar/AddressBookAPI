using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using AddressBookAPI.Helpers;
using AddressBookAPI.Helpers.RequestParameters;
using AddressBookAPI.Helpers.Responses;
using AddressBookAPI.Services.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AddressBookAPI.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookRepository _addressBookRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRefSetMappingRepository _refSetMappingRepository;
        private readonly IRefSetRepository _refSetRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRefTermRepository _refTermRepository;
        private readonly IAssetRepository _assetRepository;

        public AddressBookService(
            IAddressBookRepository addressBookRepository,
            IUnitOfWork unitOfWork,
            IEmailRepository emailRepository,
            IPhoneRepository phoneRepository,
            IAddressRepository addressRepository,
            IRefSetMappingRepository refSetMappingRepository,
            IRefSetRepository refSetRepository,
            IRefTermRepository refTermRepository,
            IUserRepository userRepository,
            IAssetRepository assetRepository)
        {
            _addressBookRepository = addressBookRepository;
            _addressRepository = addressRepository;
            _emailRepository = emailRepository;
            _phoneRepository = phoneRepository;
            _userRepository = userRepository;
            _refSetMappingRepository = refSetMappingRepository;
            _refSetRepository = refSetRepository;
            _refTermRepository = refTermRepository;
            _assetRepository = assetRepository;
            _unitOfWork = unitOfWork;
        }

        public CountResponse GetCount(Guid userId)
        { 

            var count = _addressBookRepository.GetAddressBookCount(userId);

            return new CountResponse(true, null, new CountDTO { Count = count });
        }

        public PagedList<AddressBookToReturnDTO> GetAddressBooks(Guid userId, AddressBookResourceParameter resourceParameter)
        {
            var user = _userRepository.GetUser(userId);

            if (user == null)
                return PagedList<AddressBookToReturnDTO>.Create(new List<AddressBookToReturnDTO>(),0,1);

            var addressBooksToReturn = new List<AddressBookToReturnDTO>();

            var addressBooks = _addressBookRepository.GetAddressBooks(userId);

            foreach(var addressBook in addressBooks)
            {
                var asset = _assetRepository.GetAssetByAddressBookId(addressBook.Id);
                if (asset == null)
                    asset = new Asset();
                addressBooksToReturn.Add(new AddressBookToReturnDTO()
                {
                    Id = addressBook.Id,
                    FirstName = addressBook.FirstName,
                    LastName = addressBook.LastName,
                    Emails = getEmails(addressBook.Id),
                    Phones = getPhones(addressBook.Id),
                    Addresses = getAddresses(addressBook.Id),
                    AssetDTO = new AssetIdDTO() { FileId = asset.Id }
                });
            }

            if(resourceParameter.SortBy.ToLower() == "lastname" && resourceParameter.SortOrder.ToLower() == "asc")
            {
                addressBooksToReturn = addressBooksToReturn.OrderBy(addressBook => addressBook.LastName).ToList();
            }

            if (resourceParameter.SortBy.ToLower() == "lastname" && resourceParameter.SortOrder.ToLower() == "desc")
            {
                addressBooksToReturn = addressBooksToReturn.OrderByDescending(addressBook => addressBook.LastName).ToList();
            }

            if (resourceParameter.SortBy.ToLower() == "firstname" && resourceParameter.SortOrder.ToLower() == "asc")
            {
                addressBooksToReturn = addressBooksToReturn.OrderBy(addressBook => addressBook.FirstName).ToList();
            }

            if (resourceParameter.SortBy.ToLower() == "firstname" && resourceParameter.SortOrder.ToLower() == "desc")
            {
                addressBooksToReturn = addressBooksToReturn.OrderByDescending(addressBook => addressBook.FirstName).ToList();
            }

            return PagedList<AddressBookToReturnDTO>.Create(addressBooksToReturn,resourceParameter.PageNumber,resourceParameter.PageSize);
        }


        public AddressBookResponse GetAddressBook(Guid addressBookId, Guid tokenUserId) { 

            var addressBook = _addressBookRepository.GetAddressBookById(addressBookId);

            if (addressBook == null)
            {
                return new AddressBookResponse(false, "Address book not found",null);
            }

            if (addressBook.UserId != tokenUserId)
            {
                return new AddressBookResponse(false, "User has no access to address book", null);
            }

            var emailsListToReturn = getEmails(addressBookId);

            var phonesListToReturn = getPhones(addressBookId);

            var addressListToReturn = getAddresses(addressBookId);

            var asset = _assetRepository.GetAssetByAddressBookId(addressBookId);
            
            if (asset == null)
                asset = new Asset();
            
            var addressBookToReturn = new AddressBookToReturnDTO() { 
                Id = addressBook.Id,
                FirstName = addressBook.FirstName,
                LastName = addressBook.LastName,
                Emails = emailsListToReturn,
                Phones = phonesListToReturn,
                Addresses = addressListToReturn,
                AssetDTO = new AssetIdDTO() { FileId = asset.Id }
            };

            return new AddressBookResponse(true,"", addressBookToReturn);
        }

        public MessageResponse DeleteAddressBook(Guid addressBookId,Guid userId)
        {
            var addressBook = _addressBookRepository.GetAddressBookById(addressBookId);

            if(addressBook == null)
                return new MessageResponse(false,"Address book not found");

            if (addressBook.UserId != userId)
                return new MessageResponse(false, "User not having access");

            _addressBookRepository.DeleteAddressBook(addressBook);
            _unitOfWork.Save();

            return new MessageResponse(true,null);
        }

        public AddressBookCreationResponse CreateAddressBook(AddressBookRequestParameter addressBookData, Guid userId)
        {
            var addressBookCheck = _addressBookRepository.GetAddressBookByName(addressBookData.FirstName, addressBookData.LastName);

            if (addressBookCheck != null && addressBookCheck.UserId == userId)
                return new AddressBookCreationResponse(false, "Address book already exists with same first and last name.", null);

            var emailsAdded = addEmails(addressBookData.Emails);
            if (!emailsAdded.IsSuccess)
                return new AddressBookCreationResponse(false, emailsAdded.Message, null);

            var phonesAdded = addPhones(addressBookData.Phones);
            if (!phonesAdded.IsSuccess)
                return new AddressBookCreationResponse(false, phonesAdded.Message, null);

            var addressAdded = addAddresses(addressBookData.Addresses);
            if (!addressAdded.IsSuccess)
                return new AddressBookCreationResponse(false, addressAdded.Message, null);

            var addressBook = new AddressBookDTO() {
                Id = Guid.NewGuid(),
                FirstName = addressBookData.FirstName,
                LastName = addressBookData.LastName,
                Emails = emailsAdded.Emails,
                Phones = phonesAdded.Phones,
                Addresses = addressAdded.Addresses,
                UserId = userId,
            };

            foreach (var email in emailsAdded.Emails) {
                email.UserId = userId;
                email.AddressBookId = addressBook.Id; 
            }

            foreach (var phone in phonesAdded.Phones) { 
                phone.AddressBookId = addressBook.Id; 
                phone.UserId = userId; 
            }

            foreach (var address in addressAdded.Addresses) { 
                address.AddressBookId = addressBook.Id; 
                address.UserId = userId; 
            }

            _addressBookRepository.CreateAddressBook(addressBook);

            _unitOfWork.Save();

            return new AddressBookCreationResponse(true, "", addressBook);
        }

        public AddressBookCreationResponse UpdateAddressBook(AddressBookUpdateParameter addressBookData, Guid addressBookId,Guid userId)
        {
            var addressBookCheck = _addressBookRepository.GetAddressBookById(addressBookId);

            if (addressBookCheck == null && addressBookCheck.UserId == userId)
                return new AddressBookCreationResponse(false, "Address book not found", null);

            var emailsUpdated = UpdateEmails(addressBookData.Emails, addressBookId);
            if (!emailsUpdated.IsSuccess)
                return new AddressBookCreationResponse(false, emailsUpdated.Message, null);

            var phonesUpdated = UpdatePhones(addressBookData.Phones, addressBookId);
            if (!phonesUpdated.IsSuccess)
                return new AddressBookCreationResponse(false, phonesUpdated.Message, null);

            var addressUpdated = UpdateAddresses(addressBookData.Addresses, addressBookId);
            if (!addressUpdated.IsSuccess)
                return new AddressBookCreationResponse(false, addressUpdated.Message, null);

            addressBookCheck.FirstName = addressBookData.FirstName;
            addressBookCheck.LastName = addressBookData.LastName;

            _addressBookRepository.UpdateAddressBook(addressBookCheck,emailsUpdated.Emails,addressUpdated.Addresses,phonesUpdated.Phones);

            _unitOfWork.Save();

            return new AddressBookCreationResponse(true, "", null);
        }

        private EmailResponse addEmails(IEnumerable<EmailDTO> emails)
        {
            var emailSet = _refSetRepository.GetRefSet("EMAIL_TYPE");
            var emailTerms = _refSetMappingRepository.GetRefTermsByRefSetId(emailSet.Id);
            var emailRefTermsWithMapping = _refSetMappingRepository.GetRefTermMappingId(emailSet.Id);

            IList<Email> emailsList = new List<Email>();                                                                                                                                                                                                                

            //email validation
            bool unique = true;
            for(int i=0;i < emails.Count()-1;i++)
            {
                if(!Regex.Match(emails.ElementAt(i).EmailAddress, @"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/").Success)
                {
                    unique = false;
                    break;
                }

                for (int j = i+1; j < emails.Count(); j++)
                {
                    if (emails.ElementAt(i).EmailAddress.Equals(emails.ElementAt(i).EmailAddress))
                    {
                        unique = false;
                        break;
                    }
                }
            }

            if (!unique)
                return new EmailResponse(false,"Email data is not valid",null);

            for (int i = 0; i < emails.Count(); i++)
            {
                var refTerm = emailTerms.SingleOrDefault(refTerm => refTerm.Key.ToLower() == emails.ElementAt(i).Type.Key.ToLower());
                if (refTerm == null)
                    return new EmailResponse(false,$"Key {emails.ElementAt(i).Type.Key} was not found.", null);
                var mapping = emailRefTermsWithMapping.SingleOrDefault(mapping => mapping.RefTermId == refTerm.Id);
                if (mapping == null)
                    return new EmailResponse(false, $"Key {emails.ElementAt(i).Type.Key} was not found.", null);

                emailsList.Add(new Email
                {
                    Id = Guid.NewGuid(),
                    EmailAddress = emails.ElementAt(i).EmailAddress,
                    EmailTypeId = mapping.Id
                });
            }

            return new EmailResponse(true,null,emailsList);
        }

        private PhoneResponse addPhones(IEnumerable<PhoneDTO> phones)
        {
            var phoneSet = _refSetRepository.GetRefSet("PHONE_TYPE");
            var phoneTerms = _refSetMappingRepository.GetRefTermsByRefSetId(phoneSet.Id);
            var phoneRefTermsWithMapping = _refSetMappingRepository.GetRefTermMappingId(phoneSet.Id);

            IList<Phone> phonesList = new List<Phone>();

            //phone validation
            bool unique = true;
            for (int i = 0; i < phones.Count() - 1; i++)
            {
                if (phones.ElementAt(i).PhoneNumber.Length == 14)
                {
                    unique = false;
                    break;
                }

                for (int j = i + 1; j < phones.Count(); j++)
                {
                    if (phones.ElementAt(i).PhoneNumber.Equals(phones.ElementAt(i).PhoneNumber))
                    {
                        unique = false;
                        break;
                    }
                }
            }

            if (!unique)
                return new PhoneResponse(false, "Phone data is not valid", null);

            for (int i = 0; i < phones.Count(); i++)
            {
                var refTerm = phoneTerms.SingleOrDefault(refTerm => refTerm.Key.ToLower() == phones.ElementAt(i).Type.Key.ToLower());
                if (refTerm == null)
                    return new PhoneResponse(false, $"Key {phones.ElementAt(i).Type.Key} was not found.", null);
                var mapping = phoneRefTermsWithMapping.SingleOrDefault(mapping => mapping.RefTermId == refTerm.Id);
                if (mapping == null)
                    return new PhoneResponse(false, $"Key {phones.ElementAt(i).Type.Key} was not found.", null);

                phonesList.Add(new Phone
                {
                    Id = Guid.NewGuid(),
                    PhoneNumber = phones.ElementAt(i).PhoneNumber,
                    PhoneTypeId = mapping.Id,
                });
            }

            return new PhoneResponse(true, null, phonesList);
        }

        private AddressResponse addAddresses(IEnumerable<AddressDTO> addresses)
        {
            var addressSet = _refSetRepository.GetRefSet("ADDRESS_TYPE");
            var addressTerms = _refSetMappingRepository.GetRefTermsByRefSetId(addressSet.Id);
            var addressRefTermsWithMapping = _refSetMappingRepository.GetRefTermMappingId(addressSet.Id);

            var countrySet = _refSetRepository.GetRefSet("COUNTRY_TYPE");
            var countryTerms = _refSetMappingRepository.GetRefTermsByRefSetId(countrySet.Id);
            var countryRefTermsWithMapping = _refSetMappingRepository.GetRefTermMappingId(countrySet.Id);

            IList<Address> addressesList = new List<Address>();

            for (int i = 0; i < addresses.Count(); i++)
            {
                var address = addresses.ElementAt(i);

                var addressRefTerm = addressTerms.SingleOrDefault(refTerm => refTerm.Key.ToLower() == address.Type.Key.ToLower());
                if (addressRefTerm == null)
                    return new AddressResponse(false, $"Key {address.Type.Key} was not found.", null);
                var addressMapping = addressRefTermsWithMapping.SingleOrDefault(mapping => mapping.RefTermId == addressRefTerm.Id);
                if (addressMapping == null)
                    return new AddressResponse(false, $"Key {address.Type.Key} was not found.", null);

                var countryRefTerm = countryTerms.SingleOrDefault(refTerm => refTerm.Key.ToLower() == address.Country.Key.ToLower());
                if (countryRefTerm == null)
                    return new AddressResponse(false, $"Key {address.Country.Key} was not found.", null);
                var countryMapping = countryRefTermsWithMapping.SingleOrDefault(mapping => mapping.RefTermId == countryRefTerm.Id);
                if (countryMapping == null)
                    return new AddressResponse(false, $"Key {address.Country.Key} was not found.", null);

                addressesList.Add(new Address
                {
                    Id = Guid.NewGuid(),
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    City = address.City,
                    StateName = address.StateName,
                    ZipCode = address.ZipCode,
                    AddressTypeId = addressMapping.Id,
                    CountryTypeId = countryMapping.Id,
                });
            }

            return new AddressResponse(true, null, addressesList);
        }

        private IList<EmailToReturnDTO> getEmails(Guid addressBookId)
        {
            var emailsList = _emailRepository.GetEmailsByAddressBookId(addressBookId);
            IList<EmailToReturnDTO> emailsListToReturn = new List<EmailToReturnDTO>();
            foreach (var email in emailsList)
            {
                var refSetMapping = _refSetMappingRepository.GetRefSetMapping(email.EmailTypeId);
                var refTerm = _refTermRepository.GetRefTerm(refSetMapping.RefTermId);
                emailsListToReturn.Add(new EmailToReturnDTO()
                {
                    Id = email.Id,
                    EmailAddress = email.EmailAddress,
                    Type = new Entities.Models.Type() { Key = refTerm.Key }
                });
            }

            return emailsListToReturn;
        }

        private IList<PhoneToReturnDTO> getPhones(Guid addressBookId)
        {
            var phonesList = _phoneRepository.GetPhonesByAddressBookId(addressBookId);
            IList<PhoneToReturnDTO> phonesListToReturn = new List<PhoneToReturnDTO>();
            foreach (var phone in phonesList)
            {
                var refSetMapping = _refSetMappingRepository.GetRefSetMapping(phone.PhoneTypeId);
                var refTerm = _refTermRepository.GetRefTerm(refSetMapping.RefTermId);
                phonesListToReturn.Add(new PhoneToReturnDTO()
                {
                    Id = phone.Id,
                    PhoneNumber = phone.PhoneNumber,
                    Type = new Entities.Models.Type() { Key = refTerm.Key }
                });
            }

            return phonesListToReturn;
        }

        private IList<AddressToReturnDTO> getAddresses(Guid addressBookId)
        {
            var addressList = _addressRepository.GetAddresssByAddressBookId(addressBookId);
            IList<AddressToReturnDTO> addressListToReturn = new List<AddressToReturnDTO>();
            foreach (var address in addressList)
            {
                var refSetMapping = _refSetMappingRepository.GetRefSetMapping(address.AddressTypeId);
                var typeRefTerm = _refTermRepository.GetRefTerm(refSetMapping.RefTermId);
                refSetMapping = _refSetMappingRepository.GetRefSetMapping(address.CountryTypeId);
                var countryRefTerm = _refTermRepository.GetRefTerm(refSetMapping.RefTermId);
                addressListToReturn.Add(new AddressToReturnDTO()
                {
                    Id = address.Id,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    City = address.City,
                    StateName = address.StateName,
                    ZipCode = address.ZipCode,
                    Type = new Entities.Models.Type() { Key = typeRefTerm.Key },
                    Country = new Entities.Models.Type() { Key = countryRefTerm.Key },
                });
            }

            return addressListToReturn;
        }

        private EmailResponse UpdateEmails(IEnumerable<EmailUpdationDTO> emails, Guid addressbookId)
        {
            var emailSet = _refSetRepository.GetRefSet("EMAIL_TYPE");
            var emailTerms = _refSetMappingRepository.GetRefTermsByRefSetId(emailSet.Id);
            var emailRefTermsWithMapping = _refSetMappingRepository.GetRefTermMappingId(emailSet.Id);

            IList<Email> emailsList = new List<Email>();
            var emailsInDB = _emailRepository.GetEmailsByAddressBookId(addressbookId);

            if(emailsInDB.Count() != emails.Count())
                return new EmailResponse(false, "Additional email address data given", null);

            foreach(var emailFromDB in emailsInDB)
            {
                var DoesExists = emails.Where(email => email.Id == emailFromDB.Id);
                if (DoesExists == null)
                    return new EmailResponse(false, "Given email address data not found in the address book", null);
            }

            //email validation
            bool unique = true;
            for (int i = 0; i < emails.Count() - 1; i++)
            { 
                for (int j = i + 1; j < emails.Count(); j++)
                {
                    if (emails.ElementAt(i).EmailAddress.Equals(emails.ElementAt(i).EmailAddress))
                    {
                        unique = false;
                        break;
                    }
                }
            }

            if (!unique)
                return new EmailResponse(false, "Email address duplication found", null);

            for (int i = 0; i < emails.Count() - 1; i++)
            {
                for (int j = i + 1; j < emails.Count(); j++)
                {
                    if (!Regex.Match(emails.ElementAt(i).EmailAddress, @"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/").Success)
                    {
                        unique = false;
                        break;
                    }
                }
            }

            if (!unique)
                return new EmailResponse(false, "Email address not valid", null);

            for (int i = 0; i < emails.Count(); i++)
            {
                var refTerm = emailTerms.SingleOrDefault(refTerm => refTerm.Key.ToLower() == emails.ElementAt(i).Type.Key.ToLower());
                if (refTerm == null)
                    return new EmailResponse(false, $"Key {emails.ElementAt(i).Type.Key} was not found.", null);
                var mapping = emailRefTermsWithMapping.SingleOrDefault(mapping => mapping.RefTermId == refTerm.Id);
                if (mapping == null)
                    return new EmailResponse(false, $"Key {emails.ElementAt(i).Type.Key} was not found.", null);

                emailsList.Add(new Email
                {
                    Id = emails.ElementAt(i).Id,
                    EmailAddress = emails.ElementAt(i).EmailAddress,
                    EmailTypeId = mapping.Id
                });
            }
            
            foreach(var email in emailsList)
            {
                int index = emailsInDB.ToList().FindIndex(emailFromDB => emailFromDB.Id == email.Id);
                var emailFromDB = emailsInDB.ToList().ElementAt(index);
                emailFromDB.EmailAddress = email.EmailAddress;
                emailFromDB.EmailTypeId = email.EmailTypeId;
            }

            return new EmailResponse(true, "", emailsInDB);
        }

        private PhoneResponse UpdatePhones(IEnumerable<PhoneUpdationDTO> phones, Guid addressbookId)
        {
            var phoneSet = _refSetRepository.GetRefSet("PHONE_TYPE");
            var phoneTerms = _refSetMappingRepository.GetRefTermsByRefSetId(phoneSet.Id);
            var phoneRefTermsWithMapping = _refSetMappingRepository.GetRefTermMappingId(phoneSet.Id);

            IList<Phone> phonesList = new List<Phone>();
            var phonesInDB = _phoneRepository.GetPhonesByAddressBookId(addressbookId);

            if (phonesInDB.Count() != phones.Count())
                return new PhoneResponse(false, "Additional phone number data given", null);

            foreach (var phoneFromDB in phonesInDB)
            {
                var DoesExists = phones.Where(phone => phone.Id == phoneFromDB.Id);
                if (DoesExists == null)
                    return new PhoneResponse(false, "Given phone number data not found in the address book", null);
            }

            //phone validation
            bool unique = true;
            for (int i = 0; i < phones.Count() - 1; i++)
            {
                for (int j = i + 1; j < phones.Count(); j++)
                {
                    if (phones.ElementAt(i).PhoneNumber.Length == 13)
                    {
                        unique = false;
                        break;
                    }
                }
            }

            if (!unique)
                return new PhoneResponse(false, "Phone number is not valid", null);

            for (int i = 0; i < phones.Count() - 1; i++)
            {

                for (int j = i + 1; j < phones.Count(); j++)
                {
                    if (phones.ElementAt(i).PhoneNumber.Equals(phones.ElementAt(i).PhoneNumber))
                    {
                        unique = false;
                        break;
                    }
                }
            }

            if (!unique)
                return new PhoneResponse(false, "Duplicate Phone data is found", null);

            for (int i = 0; i < phones.Count(); i++)
            {
                var refTerm = phoneTerms.SingleOrDefault(refTerm => refTerm.Key.ToLower() == phones.ElementAt(i).Type.Key.ToLower());
                if (refTerm == null)
                    return new PhoneResponse(false, $"Key {phones.ElementAt(i).Type.Key} was not found.", null);
                var mapping = phoneRefTermsWithMapping.SingleOrDefault(mapping => mapping.RefTermId == refTerm.Id);
                if (mapping == null)
                    return new PhoneResponse(false, $"Key {phones.ElementAt(i).Type.Key} was not found.", null);

                phonesList.Add(new Phone
                {
                    Id = phones.ElementAt(i).Id,
                    PhoneNumber = phones.ElementAt(i).PhoneNumber,
                    PhoneTypeId = mapping.Id,
                });
            }

            foreach (var phone in phonesList)
            {
                int index = phonesInDB.ToList().FindIndex(phoneFromDB => phoneFromDB.Id == phone.Id);
                var phoneFromDB = phonesInDB.ToList().ElementAt(index);
                phoneFromDB.PhoneNumber = phone.PhoneNumber;
                phoneFromDB.PhoneTypeId = phone.PhoneTypeId;
            }

            return new PhoneResponse(true, null, phonesInDB);
        }

        private AddressResponse UpdateAddresses(IEnumerable<AddressUpdationDTO> addresses, Guid addressBookId)
        {
            var addressSet = _refSetRepository.GetRefSet("ADDRESS_TYPE");
            var addressTerms = _refSetMappingRepository.GetRefTermsByRefSetId(addressSet.Id);
            var addressRefTermsWithMapping = _refSetMappingRepository.GetRefTermMappingId(addressSet.Id);

            var countrySet = _refSetRepository.GetRefSet("COUNTRY_TYPE");
            var countryTerms = _refSetMappingRepository.GetRefTermsByRefSetId(countrySet.Id);
            var countryRefTermsWithMapping = _refSetMappingRepository.GetRefTermMappingId(countrySet.Id);

            IList<Address> addressesList = new List<Address>();
            var addressesInDB = _addressRepository.GetAddresssByAddressBookId(addressBookId);

            if (addressesInDB.Count() != addresses.Count())
                return new AddressResponse(false, "Additional address data given", null);

            foreach (var addressFromDB in addressesInDB)
            {
                var DoesExists = addresses.Where(address => address.Id == addressFromDB.Id);
                if (DoesExists == null)
                    return new AddressResponse(false, "Given address data not found in the address book", null);
            }

            for (int i = 0; i < addresses.Count(); i++)
            {
                var address = addresses.ElementAt(i);

                var addressRefTerm = addressTerms.SingleOrDefault(refTerm => refTerm.Key.ToLower() == address.Type.Key.ToLower());
                if (addressRefTerm == null)
                    return new AddressResponse(false, $"Key {address.Type.Key} was not found.", null);
                var addressMapping = addressRefTermsWithMapping.SingleOrDefault(mapping => mapping.RefTermId == addressRefTerm.Id);
                if (addressMapping == null)
                    return new AddressResponse(false, $"Key {address.Type.Key} was not found.", null);

                var countryRefTerm = countryTerms.SingleOrDefault(refTerm => refTerm.Key.ToLower() == address.Country.Key.ToLower());
                if (countryRefTerm == null)
                    return new AddressResponse(false, $"Key {address.Country.Key} was not found.", null);
                var countryMapping = countryRefTermsWithMapping.SingleOrDefault(mapping => mapping.RefTermId == countryRefTerm.Id);
                if (countryMapping == null)
                    return new AddressResponse(false, $"Key {address.Country.Key} was not found.", null);

                addressesList.Add(new Address
                {
                    Id = address.Id,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    City = address.City,
                    StateName = address.StateName,
                    ZipCode = address.ZipCode,
                    AddressTypeId = addressMapping.Id,
                    CountryTypeId = countryMapping.Id,
                });
            }

            foreach (var address in addressesList)
            {
                int index = addressesInDB.ToList().FindIndex(addressFromDB => addressFromDB.Id == address.Id);
                var addressFromDB = addressesInDB.ToList().ElementAt(index);
                addressFromDB.Line1 = address.Line1;
                addressFromDB.Line2 = address.Line2;
                addressFromDB.City = address.City;
                addressFromDB.StateName = address.StateName;
                addressFromDB.ZipCode = address.ZipCode;
                addressFromDB.AddressTypeId = address.AddressTypeId;
                addressFromDB.CountryTypeId = address.CountryTypeId;
            }

            return new AddressResponse(true, null, addressesInDB);
        }

    }
}
