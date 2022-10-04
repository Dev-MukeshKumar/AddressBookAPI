using System;

namespace AddressBookAPI.Entities.Models
{
    public class EmailDTO
    {
        public string EmailAddress { get; set; }
        public Type Type { get; set; }
    }

    public class EmailUpdationDTO : EmailDTO
    {
        public Guid Id { get; set; }
    }

    public class EmailToReturnDTO: EmailUpdationDTO { }
}
