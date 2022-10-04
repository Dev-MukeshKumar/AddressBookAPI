using AddressBookAPI.Entities.DataSets;

namespace AddressBookAPI.Helpers.Responses
{
    public class UserResponse: MessageResponse
    {
        public User user { get; protected set; }
        public UserResponse(bool isSuccess, string message, User user): base(isSuccess, message)
        {
            this.user = user;
        } 
    }
}
