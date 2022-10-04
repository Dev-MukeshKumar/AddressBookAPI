using AddressBookAPI.Entities.DataSets;
using System;

namespace AddressBookAPI.Services.Repositories
{
    public interface IAssetRepository
    {
        void AddAsset(Asset assetData);
        void DeleteAsset(Asset assetData);
        Asset GetAssetByAddressBookId(Guid AddressBookId);
        Asset GetAssetByAssetId(Guid AssetId);
        void UpdateAsset(Asset assetData);
    }
}