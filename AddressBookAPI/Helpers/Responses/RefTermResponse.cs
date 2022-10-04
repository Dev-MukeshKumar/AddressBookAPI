using AddressBookAPI.Entities.DataSets;

namespace AddressBookAPI.Helpers.Responses
{
    public class RefTermResponse: MessageResponse
    {
        public RefTerm RefTerm { get; protected set; }

        public RefTermResponse(bool isSuccess, string message, RefTerm refTerm) : base(isSuccess, message)
        {
            RefTerm = refTerm;
        }
    }
}
