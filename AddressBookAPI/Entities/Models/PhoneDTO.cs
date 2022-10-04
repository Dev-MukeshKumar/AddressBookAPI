using System;

namespace AddressBookAPI.Entities.Models
{
    public class PhoneDTO
    {
        public string PhoneNumber { get; set; }
        public Type Type { get; set; }
    }

    public class PhoneUpdationDTO: PhoneDTO
    {
        public Guid Id { get; set; }
    }

    public class PhoneToReturnDTO: PhoneUpdationDTO { }
}
