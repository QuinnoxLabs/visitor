using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IGuestEntryRepository : IRepository<OdcGuestEntry>
    {
        Task<CreateUserResponse> Create(Guid guestId, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId);

        Task<List<OdcGuestEntry>> GetByGuid(Guid guestId);

    }
}
