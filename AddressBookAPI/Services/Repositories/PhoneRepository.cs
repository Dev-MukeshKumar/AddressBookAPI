using AddressBookAPI.Context;
using AddressBookAPI.Entities.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookAPI.Services.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly AddressBookDbContext _context;

        public PhoneRepository(AddressBookDbContext context)
        {
            _context = context;
        }

        public void AddPhone(Phone Phone)
        {
            _context.Phones.Add(Phone);
        }

        public void AddPhones(IList<Phone> Phone)
        {
            _context.Phones.AddRange(Phone);
        }

        public ICollection<Phone> GetPhoneByUserId(Guid userId)
        {
            var phones = _context.Phones.ToList();
            return phones.FindAll(phone => phone.UserId == userId);
        }

        public ICollection<Phone> GetPhonesByAddressBookId(Guid addressBookId)
        {
            var phones = _context.Phones.ToList();
            return phones.FindAll(phone => phone.AddressBookId == addressBookId);
        }

        public void UpdatePhone(IList<Phone> phone)
        {
            _context.Phones.UpdateRange(phone);
        }

        public void DeletePhone(IList<Phone> phone)
        {
            _context.Phones.RemoveRange(phone);
        }
    }
}
