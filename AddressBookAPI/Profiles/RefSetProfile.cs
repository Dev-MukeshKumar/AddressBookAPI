using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using AutoMapper;

namespace AddressBookAPI.Profiles
{
    public class RefSetProfile: Profile
    {
        public RefSetProfile()
        {
            CreateMap<RefSetCreationDTO, RefSet>();
            CreateMap<RefSet, RefSetToReturnDTO>();
        }
    }
}
