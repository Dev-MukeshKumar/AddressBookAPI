using AddressBookAPI.Entities.DataSets;
using System.Collections.Generic;

namespace AddressBookAPI.Helpers.Responses
{
    public class AddressResponse: MessageResponse
    {
        public IEnumerable<Address> Addresses { get; protected set; }

        public AddressResponse(bool isSuccess, string message, IEnumerable<Address> addresses): base(isSuccess, message)
        {
            Addresses = addresses;
        }
    }
}
