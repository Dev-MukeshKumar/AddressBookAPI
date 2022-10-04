using AddressBookAPI.Entities.DataSets;

namespace AddressBookAPI.Helpers.Responses
{
    public class RefSetResponse: MessageResponse
    {
        public RefSet RefSet { get; protected set; }

        public RefSetResponse(bool isSuccess, string message,RefSet refSet) : base(isSuccess,message) { 
            RefSet = refSet;
        }
    }
}
