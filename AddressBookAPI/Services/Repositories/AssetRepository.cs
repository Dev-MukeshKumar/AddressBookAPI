using AddressBookAPI.Context;
using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using System;
using System.Linq;

namespace AddressBookAPI.Services.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AddressBookDbContext _context;

        public AssetRepository(AddressBookDbContext context)
        {
            _context = context;
        }

        public void AddAsset(Asset assetData)
        {
            if (assetData == null)
                throw new ArgumentNullException(nameof(assetData) + " was null in AddAsset from AssetRepository");

            _context.Assets.Add(assetData);
        }

        public Asset GetAssetByAssetId(Guid AssetId)
        {
            if (AssetId == null || AssetId == Guid.Empty)
                throw new ArgumentNullException(nameof(AssetId) + " was null in GetAsset from AssetRepository");

            return _context.Assets.SingleOrDefault(asset => asset.Id == AssetId);
        }

        public Asset GetAssetByAddressBookId(Guid AddressBookId)
        {
            if (AddressBookId == null || AddressBookId == Guid.Empty)
                throw new ArgumentNullException(nameof(AddressBookId) + " was null in GetAsset from AssetRepository");

            return _context.Assets.SingleOrDefault(asset => asset.AddressBookId == AddressBookId);
        }

        public void UpdateAsset(Asset assetData)
        {
            if (assetData == null)
                throw new ArgumentNullException(nameof(assetData) + " was null in UpdateAsset from AssetRepository");

            _context.Assets.Update(assetData);
        }

        public void DeleteAsset(Asset assetData)
        {
            if (assetData == null)
                throw new ArgumentNullException(nameof(assetData) + " was null in DeleteAsset from AssetRepository");

            _context.Assets.Remove(assetData);
        }

    }
}
