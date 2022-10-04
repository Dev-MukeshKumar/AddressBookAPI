using System;

namespace AddressBookAPI.Entities.Models
{
    public class RefTermDTO
    {
        public string Key { get; set; }
        public string Description { get; set; }
    }

    public class RefTermCreationDTO : RefTermDTO { }

    public class RefTermUpdationDTO : RefTermDTO { }

    public class RefTermToReturnDTO : RefTermDTO { 
        public Guid Id { get; set; }
    }

}
