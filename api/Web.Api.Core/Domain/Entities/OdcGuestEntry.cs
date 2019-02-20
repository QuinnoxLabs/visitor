using System;
using System.Collections.Generic;
using System.Linq;
using Web.Api.Core.Shared;


namespace Web.Api.Core.Domain.Entities
{
    public class OdcGuestEntry : BaseEntity
    {
        public Guid OdcGuestUserId { get; private set; }
        public OdcGuestUser OdcGuestUser { get; set; }
        
        internal OdcGuestEntry() { /* Required by EF */ }

        internal OdcGuestEntry(Guid guestId, DateTime created)
        {
            OdcGuestUserId = guestId;
            Created = created;
        }
    }
}
