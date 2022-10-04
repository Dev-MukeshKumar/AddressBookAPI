using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using AutoMapper;

namespace AddressBookAPI.Profiles
{
    public class RefTermProfile: Profile
    {
        public RefTermProfile()
        {
            CreateMap<RefTermCreationDTO, RefTerm>();
            CreateMap<RefTerm, RefTermToReturnDTO>();
        }
    }
}
