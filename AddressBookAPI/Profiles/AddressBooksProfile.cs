using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using AddressBookAPI.Helpers.RequestParameters;
using AutoMapper;

namespace AddressBookAPI.Profiles
{
    public class AddressBooksProfile: Profile
    {
        public AddressBooksProfile()
        {
            CreateMap<AddressBookRequestParameter, AddressBookDTO>();

            CreateMap<EmailDTO, Email>();
            CreateMap<PhoneDTO, Phone>();
            CreateMap<AddressDTO, Address>();

        }
    }
}
