using System;

namespace Web.Api.Models.Request
{
    public class GuestUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClientId { get; set; }
        public Guid Key { get; set; }
    }
}
