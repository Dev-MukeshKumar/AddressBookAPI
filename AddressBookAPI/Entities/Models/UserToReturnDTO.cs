using System;

namespace AddressBookAPI.Entities.Models
{
    public class UserToReturnDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
