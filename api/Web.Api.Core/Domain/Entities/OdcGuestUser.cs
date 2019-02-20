using System;
using System.Collections.Generic;
using System.Linq;
using Web.Api.Core.Shared;


namespace Web.Api.Core.Domain.Entities
{
    public class OdcGuestUser : BaseEntity
    {
        public string FirstName { get; private set; } // EF migrations require at least private setter - won't work on auto-property
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsEmailSent { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? ActivationDate { get; private set; }
        public DateTime? DeactivationDate { get; private set; }
        public string ClientId { get; private set; }
        public Guid CreatedBy { get; private set; }
        public User User { get; set; }
        public List<OdcGuestEntry> GuestEntries { get; set; }
        internal OdcGuestUser() { /* Required by EF */ }

        //Create guest entry
        internal OdcGuestUser(string firstName, string lastName, string email, DateTime startDate, DateTime endDate, Guid createdBy, bool isEmailSent, bool isActive, DateTime? activationDate, DateTime? deactivationDate, string clientId, DateTime created)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StartDate = startDate;
            EndDate = endDate;
            CreatedBy = createdBy;
            IsEmailSent = isEmailSent;
            IsActive = isActive;
            ActivationDate = activationDate;
            DeactivationDate = deactivationDate;
            ClientId = clientId;
            Created = created;
        }

        //Update guest endtry
        internal OdcGuestUser(Guid guestId, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, Guid createdBy, bool isEmailSent, bool isActive, DateTime? activationDate, DateTime? deactivationDate, string clientId, DateTime created)
        {
            Id = guestId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StartDate = startDate;
            EndDate = endDate;
            CreatedBy = createdBy;
            IsEmailSent = isEmailSent;
            IsActive = isActive;
            ActivationDate = activationDate;
            DeactivationDate = deactivationDate;
            ClientId = clientId;
            Created = created;
        }

        //Send email and update
        internal OdcGuestUser(OdcGuestUser odcGuestUser, bool isEmailSent)
        {
            Id = odcGuestUser.Id;
            FirstName = odcGuestUser.FirstName;
            LastName = odcGuestUser.LastName;
            Email = odcGuestUser.Email;
            StartDate = odcGuestUser.StartDate;
            EndDate = odcGuestUser.EndDate;
            CreatedBy = odcGuestUser.CreatedBy;
            IsEmailSent = isEmailSent;
            IsActive = odcGuestUser.IsActive;
            ActivationDate = odcGuestUser.ActivationDate;
            DeactivationDate = odcGuestUser.DeactivationDate;
            ClientId = odcGuestUser.ClientId;
        }

        //Set active and activationdate
        internal OdcGuestUser(OdcGuestUser odcGuestUser, bool isActive, DateTime? activationDate)
        {
            Id = odcGuestUser.Id;
            FirstName = odcGuestUser.FirstName;
            LastName = odcGuestUser.LastName;
            Email = odcGuestUser.Email;
            StartDate = odcGuestUser.StartDate;
            EndDate = odcGuestUser.EndDate;
            CreatedBy = odcGuestUser.CreatedBy;
            IsEmailSent = odcGuestUser.IsEmailSent;
            IsActive = isActive;
            ActivationDate = activationDate;
            DeactivationDate = activationDate;
            ClientId = odcGuestUser.ClientId;
        }

        //Set deactivation date
        internal OdcGuestUser(OdcGuestUser odcGuestUser, DateTime? deactivationDate)
        {
            Id = odcGuestUser.Id;
            FirstName = odcGuestUser.FirstName;
            LastName = odcGuestUser.LastName;
            Email = odcGuestUser.Email;
            StartDate = odcGuestUser.StartDate;
            EndDate = odcGuestUser.EndDate;
            CreatedBy = odcGuestUser.CreatedBy;
            IsEmailSent = odcGuestUser.IsEmailSent;
            IsActive = odcGuestUser.IsActive;
            ActivationDate = odcGuestUser.ActivationDate;
            DeactivationDate = deactivationDate;
            ClientId = odcGuestUser.ClientId;
        }
    }
}