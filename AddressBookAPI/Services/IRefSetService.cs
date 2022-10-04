using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Helpers.Responses;
using System;

namespace AddressBookAPI.Services
{
    public interface IRefSetService
    {
        RefSetResponse CreateRefSet(RefSet refSetData);
        RefSetResponse GetRefSetByName(string set);
        RefSetResponse GetRefSetById(Guid setId);
        RefTermListResponse GetRefTermsByRefSetId(Guid setId);
        RefSetResponse DeleteRefSetById(Guid setId);
    }
}