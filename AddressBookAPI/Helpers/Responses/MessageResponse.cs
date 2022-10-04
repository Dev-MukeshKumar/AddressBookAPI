namespace AddressBookAPI.Helpers.Responses
{
    public class MessageResponse
    {
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }

        public MessageResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
