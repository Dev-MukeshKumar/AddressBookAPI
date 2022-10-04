using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Helpers.Responses;
using Microsoft.AspNetCore.Http;
using System;

namespace AddressBookAPI.Services
{
    public interface IAssetService
    {
        AssetResponse AddAsset(Guid addressBookId, Guid tokenUserId, Asset assetData, IFormFile file);
        AssetResponse GetAsset(Guid assetId, Guid tokenUserId);
    }
}