using System.Collections.Generic;
using System;
using AddressBookAPI.Entities.DataSets;

namespace AddressBookAPI.Entities.Models
{
    public class AddressBookDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Email> Emails { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public AssetIdDTO Asset { get; set; }
    }
}
