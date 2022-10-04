using AddressBookAPI.Entities.DataSets;
using System;
using System.Collections.Generic;

namespace AddressBookAPI.Services.Repositories
{
    public interface IPhoneRepository
    {
        void AddPhone(Phone Phone);
        void AddPhones(IList<Phone> Phone);
        void DeletePhone(IList<Phone> phone);
        ICollection<Phone> GetPhoneByUserId(Guid userId);
        ICollection<Phone> GetPhonesByAddressBookId(Guid addressBookId);
        void UpdatePhone(IList<Phone> phone);
    }
}