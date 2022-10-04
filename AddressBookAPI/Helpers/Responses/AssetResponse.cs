using AddressBookAPI.Entities.DataSets;

namespace AddressBookAPI.Helpers.Responses
{
    public class AssetResponse: MessageResponse
    {
        public Asset Asset { get; protected set; }

        public AssetResponse(bool isSuccess, string message,Asset assetData): base(isSuccess, message)
        {
            Asset = assetData;
        }
    }
}
