using AddressBookAPI.Entities.DataSets;
using System;

namespace AddressBookAPI.Services.Repositories
{
    public interface IRefTermRepository
    {
        void AddRefTerm(RefTerm refTermData);
        void DeleteRefTerm(RefTerm refTermData);
        RefTerm GetRefTerm(Guid refTermId);
        RefTerm GetRefTerm(string key);
        void UpdateRefTerm(RefTerm refTermData);
    }
}