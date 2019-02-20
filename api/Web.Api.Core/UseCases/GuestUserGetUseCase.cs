using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public sealed class GuestUserGetUseCase : IGuestUserGetUseCase
    {
        private readonly IGuestUserRepository _guestUserRepository;

        public GuestUserGetUseCase(IGuestUserRepository guestUserRepository)
        {
            _guestUserRepository = guestUserRepository;
        }

        public async Task<bool> Handle(GuestUserRequest message, IOutputPort<GuestUserResponse> outputPort)
        {
            var response = await _guestUserRepository.GetAll();
            outputPort.Handle(new GuestUserResponse(response, true, ""));
            return true;
        }
    }
}
