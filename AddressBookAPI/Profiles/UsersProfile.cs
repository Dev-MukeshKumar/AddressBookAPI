using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using AutoMapper;

namespace AddressBookAPI.Profiles
{
    public class UsersProfile: Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserToReturnDTO>();

        }
    }
}
