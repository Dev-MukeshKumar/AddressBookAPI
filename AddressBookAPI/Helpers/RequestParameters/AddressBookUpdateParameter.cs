using AddressBookAPI.Entities.Models;
using System.Collections.Generic;
using System;

namespace AddressBookAPI.Helpers.RequestParameters
{
    public class AddressBookUpdateParameter
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<EmailUpdationDTO> Emails { get; set; }
        public IEnumerable<AddressUpdationDTO> Addresses { get; set; }
        public IEnumerable<PhoneUpdationDTO> Phones { get; set; }
        public AssetIdDTO Asset { get; set; }
    }
}
