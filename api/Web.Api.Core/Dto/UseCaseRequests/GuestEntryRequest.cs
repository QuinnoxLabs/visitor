using System;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class GuestEntryRequest : IUseCaseRequest<GuestEntryResponse>
    {
        public Guid GuestId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string ClientId { get; }


        public GuestEntryRequest()
        {

        }

        public GuestEntryRequest(Guid guestId)
        {
            GuestId = guestId;
        }

        public GuestEntryRequest(Guid guestId, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId)
        {
            GuestId = guestId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StartDate = startDate;
            EndDate = endDate;
            ClientId = clientId;
        }
    }
}