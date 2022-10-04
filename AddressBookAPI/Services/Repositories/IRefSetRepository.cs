using AddressBookAPI.Entities.DataSets;
using System;

namespace AddressBookAPI.Services.Repositories
{
    public interface IRefSetRepository
    {
        void AddRefSet(RefSet refSetData);
        void DeleteRefSet(RefSet refSetData);
        RefSet GetRefSet(Guid refSetId);
        RefSet GetRefSet(string set);
        void UpdateRefSet(RefSet refSetData);
    }
}