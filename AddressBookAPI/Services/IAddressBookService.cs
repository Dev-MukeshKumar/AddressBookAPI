using AddressBookAPI.Helpers.RequestParameters;
using AddressBookAPI.Helpers.Responses;
using System;

namespace AddressBookAPI.Services
{
    public interface IAddressBookService
    {
        CountResponse GetCount(Guid userId);
        AddressBookResponse GetAddressBook(Guid addressBookId, Guid tokenUserId);
        MessageResponse DeleteAddressBook(Guid addressBookId, Guid userId);
        AddressBookCreationResponse CreateAddressBook(AddressBookRequestParameter addressBookData, Guid userId);

    }
}