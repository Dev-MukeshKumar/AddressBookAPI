using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using System;
using System.Collections.Generic;

namespace AddressBookAPI.Services.Repositories
{
    public interface IAddressBookRepository
    {
        void CreateAddressBook(AddressBookDTO addressBookData);

        AddressBook GetAddressBookByName(string firstName, string lastName);

        AddressBook GetAddressBookById(Guid AddressBookId);

        int GetAddressBookCount(Guid userId);

        void DeleteAddressBook(AddressBook addressBook);

        public List<AddressBook> GetAddressBooks(Guid userId);
    }
}