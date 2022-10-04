using AddressBookAPI.Entities.Models;

namespace AddressBookAPI.Helpers.Responses
{
    public class CountResponse: MessageResponse
    {
        public CountDTO Count { get; protected set; }

        public CountResponse(bool isSuccess, string message, CountDTO count): base(isSuccess, message)
        {
            Count = count;
        }

    }
}
