using AddressBookAPI.Entities.Models;
using System.Collections.Generic;

namespace AddressBookAPI.Helpers.RequestParameters
{
    public class AddressBookRequestParameter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<EmailDTO> Emails { get; set; }
        public IEnumerable<AddressDTO> Addresses { get; set; }
        public IEnumerable<PhoneDTO> Phones { get; set; }
    }
}
