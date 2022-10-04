using AddressBookAPI.Entities.DataSets;
using System.Collections.Generic;

namespace AddressBookAPI.Helpers.Responses
{
    public class PhoneResponse: MessageResponse
    {
        public IEnumerable<Phone> Phones { get; protected set; }
        
        public PhoneResponse(bool isSuccess, string message, IEnumerable<Phone> phones): base(isSuccess, message)
        {
            Phones = phones;
        }
    }
}
