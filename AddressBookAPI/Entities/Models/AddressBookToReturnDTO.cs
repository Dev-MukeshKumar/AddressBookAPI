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
        public IEnumerable<EmailToReturnDTO> Emails { get; set; }
        public IEnumerable<AddressToReturnDTO> Addresses { get; set; }
        public IEnumerable<PhoneToReturnDTO> Phones { get; set; }
        public AssetIdDTO AssetDTO { get; set; }
    }
}
