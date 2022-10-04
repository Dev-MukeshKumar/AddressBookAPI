using System;

namespace AddressBookAPI.Entities.Models
{
    public class RefSetMappingDTO
    {
        public Guid RefSetId { get; set; }
        public Guid RefTermId { get; set; }
    }
    
    public class RefSetMappingToReturnDTO : RefSetMappingDTO
    {
        public Guid Id { get; set; }
    }
}
