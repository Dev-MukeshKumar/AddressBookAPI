using AddressBookAPI.Entities.Models;

namespace AddressBookAPI.Helpers.Responses
{
    public class AddressBookResponse: MessageResponse
    {
        public AddressBookToReturnDTO addressBook { get; protected set; }
        public AddressBookResponse(bool isSuccess,string message,AddressBookToReturnDTO addressBook): base(isSuccess, message)
        {
            this.addressBook = addressBook;
        }
    }
}
