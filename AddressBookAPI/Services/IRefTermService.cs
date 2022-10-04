using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Helpers.Responses;
using System;

namespace AddressBookAPI.Services
{
    public interface IRefTermService
    {
        RefTermResponse CreateRefTerm(RefTerm refTermData, Guid refSetId);
        void AddRefTermMapping(Guid refTermId, Guid refSetId);
        RefTermResponse GetRefTermById(Guid refTermId);
        RefTermResponse GetRefTermByName(string key);
    }
}