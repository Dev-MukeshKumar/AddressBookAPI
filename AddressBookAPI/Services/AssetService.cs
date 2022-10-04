using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Helpers.Responses;
using AddressBookAPI.Services.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace AddressBookAPI.Services
{
    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssetRepository _assetRepository;
        private readonly IAddressBookRepository _addressBookRepository;

        public AssetService(
            IUnitOfWork unitOfWork,
            IAssetRepository assetRepository,
            IAddressBookRepository addressBookRepository)
        {
            _unitOfWork = unitOfWork;
            _assetRepository = assetRepository;
            _addressBookRepository = addressBookRepository;
        }

        public AssetResponse AddAsset(Guid addressBookId, Guid tokenUserId, Asset assetData, IFormFile file)
        {
            var addressBook = _addressBookRepository.GetAddressBookById(addressBookId);

            if (addressBook == null)
                return new AssetResponse(false, "AddressBook not found", null);

            if (!addressBook.UserId.Equals(tokenUserId))
                return new AssetResponse(false, "AddressBook not found", null);

            var assetExists = _assetRepository.GetAssetByAddressBookId(addressBookId);

            if (assetExists != null && assetExists.UserId.Equals(tokenUserId))
                return new AssetResponse(false, "Asset already exists", null);

            if (assetExists != null && !assetExists.UserId.Equals(tokenUserId))
                return new AssetResponse(false, "AddressBook not found", null);

            assetData.UserId = tokenUserId;
            assetData.AddressBookId = addressBookId;
            assetData.FileName = file.FileName;
            assetData.Size = file.Length;
            assetData.FileType = file.ContentType;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                assetData.Content = Convert.ToBase64String(ms.ToArray());
            }

            _assetRepository.AddAsset(assetData);
            _unitOfWork.Save();

            return new AssetResponse(true, null, assetData);

        }

        public AssetResponse GetAsset(Guid assetId, Guid tokenUserId)
        {
            var asset = _assetRepository.GetAssetByAssetId(assetId);

            if (asset == null)
                return new AssetResponse(false, "Asset not found", null);

            if (!asset.UserId.Equals(tokenUserId))
                return new AssetResponse(false, "Asset not found", null);

            return new AssetResponse(true, null, asset);

        }
    }
}
