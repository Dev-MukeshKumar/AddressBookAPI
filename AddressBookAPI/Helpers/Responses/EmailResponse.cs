using AddressBookAPI.Entities.DataSets;
using System.Collections.Generic;

namespace AddressBookAPI.Helpers.Responses
{
    public class EmailResponse:MessageResponse
    {
        public IEnumerable<Email> Emails { get; protected set; }

        public EmailResponse(bool isSuccess, string message, IEnumerable<Email> emails): base(isSuccess,message) {
            Emails = emails;
        }
    }
}
