using AddressBookAPI.Entities.DataSets;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AddressBookAPI.Entities.Models
{
    public class AddressBookToReturnDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<EmailDTO> Emails { get; set; }
        public IEnumerable<AddressDTO> Addresses { get; set; }
        public IEnumerable<PhoneDTO> Phones { get; set; }
        public AssetIdDTO AssetDTO { get; set; }
    }
}
