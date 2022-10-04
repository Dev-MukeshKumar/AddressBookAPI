using AddressBookAPI.Entities.DataSets;
using System.Collections.Generic;

namespace AddressBookAPI.Helpers.Responses
{
    public class RefTermListResponse:MessageResponse
    {

        public IEnumerable<RefTerm> RefTerms { get; protected set; }

        public RefTermListResponse(bool isSuccess, string message, IEnumerable<RefTerm> refTerms): base(isSuccess, message)
        {
            RefTerms = refTerms;
        }
    }
}
