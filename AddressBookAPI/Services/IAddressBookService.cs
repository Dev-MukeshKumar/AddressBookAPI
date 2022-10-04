using AddressBookAPI.Entities.Models;
using AddressBookAPI.Helpers;
using AddressBookAPI.Helpers.RequestParameters;
using AddressBookAPI.Helpers.Responses;
using System;
using System.Collections.Generic;

namespace AddressBookAPI.Services
{
    public interface IAddressBookService
    {
        CountResponse GetCount(Guid userId);
        AddressBookResponse GetAddressBook(Guid addressBookId, Guid tokenUserId);
        MessageResponse DeleteAddressBook(Guid addressBookId, Guid userId);
        AddressBookCreationResponse CreateAddressBook(AddressBookRequestParameter addressBookData, Guid userId);
        PagedList<AddressBookToReturnDTO> GetAddressBooks(Guid userId, AddressBookResourceParameter resourceParameter);
        AddressBookCreationResponse UpdateAddressBook(AddressBookUpdateParameter addressBookData, Guid addressBookId, Guid userId);
    }
}