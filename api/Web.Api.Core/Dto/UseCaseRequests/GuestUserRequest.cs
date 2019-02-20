using System;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class GuestUserRequest : IUseCaseRequest<GuestUserResponse>
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public int CreatedBy { get; }
        public string ClientId { get; }
        public Guid Key { get; }

        public GuestUserRequest()
        {

        }

        public GuestUserRequest(Guid key, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId)
        {
            Key = key;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StartDate = startDate;
            EndDate = endDate;
            ClientId = clientId;
        }

        public GuestUserRequest(Guid key, Guid guestId, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId)
        {
            Key = key;
            Id = guestId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StartDate = startDate;
            EndDate = endDate;
            ClientId = clientId;
        }

        public GuestUserRequest(Guid guestId)
        {
            Id = guestId;
        }
    }
}