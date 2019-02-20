using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IGuestUserRepository : IRepository<OdcGuestUser>
    {
        Task<CreateUserResponse> Create(Guid key, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId);

        Task<EditUserResponse> Update(Guid key, Guid guestId, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId);

        Task<DeleteUserResponse> Delete(Guid guestId);

        Task<List<OdcGuestUser>> GetAll();

    }
}
