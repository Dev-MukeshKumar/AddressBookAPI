using AddressBookAPI.Entities.DataSets;
using System;
using System.Collections.Generic;

namespace AddressBookAPI.Services.Repositories
{
    public interface IRefSetMappingRepository
    {
        void AddRefSetMapping(RefSetMapping refSetMappingData);
        RefSetMapping GetRefSetMapping(Guid refSetMappingId);
        IEnumerable<RefTerm> GetRefTermsByRefSetId(Guid refSetId); 
        IEnumerable<RefSetMapping> GetRefTermMappingId(Guid refSetId);
    }
}