﻿using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public sealed class GuestEditUserUseCase : IGuestEditUserUseCase
    {
        private readonly IGuestUserRepository _guestUserRepository;

        public GuestEditUserUseCase(IGuestUserRepository guestUserRepository)
        {
            _guestUserRepository = guestUserRepository;
        }

        public async Task<bool> Handle(GuestUserRequest message, IOutputPort<GuestUserResponse> outputPort)
        {
            var response = await _guestUserRepository.Update(message.Key, message.Id, message.FirstName, message.LastName,message.Email, message.StartDate, message.EndDate, message.ClientId);
            outputPort.Handle(response.Success ? new GuestUserResponse(response.Id, true) : new GuestUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
