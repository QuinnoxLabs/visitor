using System.Collections.Generic;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class GuestUserResponse : UseCaseResponseMessage 
    {
        public string Id { get; }
        public List<OdcGuestUser> GuestUsers { get; }
        public IEnumerable<string> Errors {  get; }

        public GuestUserResponse(IEnumerable<string> errors, bool success=false, string message=null) : base(success,message)
        {
            Errors = errors;
        }

        public GuestUserResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }

        public GuestUserResponse(List<OdcGuestUser> guestUsers, bool success = false, string message = null) : base(guestUsers, success, message)
        {
            GuestUsers = guestUsers;
        }
    }
}
