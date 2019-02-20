using System.Collections.Generic;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class GuestEntryResponse : UseCaseResponseMessage 
    {
        public string Id { get; }
        public IEnumerable<string> Errors {  get; }

        public List<OdcGuestEntry> GuestEntries { get; }

        public GuestEntryResponse(IEnumerable<string> errors, bool success=false, string message=null) : base(success,message)
        {
            Errors = errors;
        }
        public GuestEntryResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
        public GuestEntryResponse(List<OdcGuestEntry> guestEntries, bool success = false, string message = null) : base(guestEntries, success, message)
        {
            GuestEntries = guestEntries;
        }
    }
}
