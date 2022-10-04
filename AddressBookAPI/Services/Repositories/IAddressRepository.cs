using AddressBookAPI.Entities.DataSets;
using System;
using System.Collections.Generic;

namespace AddressBookAPI.Services.Repositories
{
    public interface IAddressRepository
    {
        void AddAddress(Address Address);
        void AddAddresss(IList<Address> Address);
        void DeleteAddress(IList<Address> Address);
        ICollection<Address> GetAddressByUserId(Guid userId);
        ICollection<Address> GetAddresssByAddressBookId(Guid addressBookId);
        void UpdateAddress(IList<Address> Address);
    }
}