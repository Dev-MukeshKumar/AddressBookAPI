using AddressBookAPI.Context;
using AddressBookAPI.Entities.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookAPI.Services.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AddressBookDbContext _context;

        public EmailRepository(AddressBookDbContext context)
        {
            _context = context;
        }

        public void AddEmail(Email Email)
        {
            _context.Emails.Add(Email);
        }

        public void AddEmails(IList<Email> Email)
        {
            _context.Emails.AddRange(Email);
        }

        public IEnumerable<Email> GetEmailByUserId(Guid userId)
        {
            var Emails = _context.Emails.ToList();
            return Emails.FindAll(Email => Email.UserId == userId);
        }

        public IEnumerable<Email> GetEmailsByAddressBookId(Guid addressBookId)
        {
            var Emails = _context.Emails.ToList();
            return Emails.FindAll(Email => Email.AddressBookId == addressBookId);
        }

        public void UpdateEmail(IList<Email> Email)
        {
            _context.Emails.UpdateRange(Email);
        }

        public void DeleteEmail(IList<Email> Email)
        {
            _context.Emails.RemoveRange(Email);
        }
    }
}
