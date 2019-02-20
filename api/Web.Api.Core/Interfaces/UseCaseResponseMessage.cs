
using System.Collections.Generic;
using Web.Api.Core.Domain.Entities;

namespace Web.Api.Core.Interfaces
{
    public abstract class UseCaseResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }
        public List<OdcGuestUser> GuestUsers { get; }
        public List<OdcGuestEntry> GuestEntries { get; }

        protected UseCaseResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }

        protected UseCaseResponseMessage(List<OdcGuestUser> guestUsers, bool success = false, string message = null)
        {
            GuestUsers = guestUsers;
            Success = success;
            Message = message;
        }

        protected UseCaseResponseMessage(List<OdcGuestEntry> guestEntries, bool success = false, string message = null)
        {
            GuestEntries = guestEntries;
            Success = success;
            Message = message;
        }
    }
}
