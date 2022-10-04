using AddressBookAPI.Entities.Models;

namespace AddressBookAPI.Helpers.Responses
{
    public class AddressBookCreationResponse: MessageResponse
    {
        public AddressBookDTO AddressBook { get; protected set; }
        public AddressBookCreationResponse(bool isSuccess, string message, AddressBookDTO addressBook): base(isSuccess, message)
        {
            AddressBook = addressBook;
        }
    }
}
