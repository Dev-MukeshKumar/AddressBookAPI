using System;

namespace AddressBookAPI.Entities.Models
{
    public class RefSetDTO
    {
        public string Set { get; set; }
        public string Description { get; set; }
    }

    public class RefSetCreationDTO: RefSetDTO { }

    public class RefSetUpdationDTO: RefSetDTO { }

    public class RefSetToReturnDTO: RefSetDTO { 
        public Guid Id { get; set; }
    }
}
