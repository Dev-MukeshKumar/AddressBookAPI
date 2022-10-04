using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using AddressBookAPI.Helpers.RequestParameters;
using AutoMapper;

namespace AddressBookAPI.Profiles
{
    public class AssetsProfile: Profile
    {
        public AssetsProfile()
        {
            CreateMap<AssetRequestParameter, Asset>();
            CreateMap<Asset, AssetToReturnDTO>();
        }
    }
}
