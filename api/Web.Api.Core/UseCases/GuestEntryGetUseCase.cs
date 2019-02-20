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
    public sealed class GuestEntryGetUseCase : IGuestEntryGetUseCase
    {
        private readonly IGuestEntryRepository _guestEntryRepository;

        public GuestEntryGetUseCase(IGuestEntryRepository guestEntryRepository)
        {
            _guestEntryRepository = guestEntryRepository;
        }

        public async Task<bool> Handle(GuestEntryRequest message, IOutputPort<GuestEntryResponse> outputPort)
        {
            var response = await _guestEntryRepository.GetByGuid(message.GuestId);
            outputPort.Handle(new GuestEntryResponse(response, true, ""));
            return true;
        }
    }
}
