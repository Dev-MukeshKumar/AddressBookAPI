using AddressBookAPI.Entities.DataSets;
using System;
using System.Collections.Generic;

namespace AddressBookAPI.Services.Repositories
{
    public interface IEmailRepository
    {
        void AddEmail(Email Email);
        void AddEmails(IList<Email> Email);
        void DeleteEmail(IList<Email> Email);
        IEnumerable<Email> GetEmailByUserId(Guid userId);
        IEnumerable<Email> GetEmailsByAddressBookId(Guid addressBookId);
        void UpdateEmail(IList<Email> Email);
    }
}