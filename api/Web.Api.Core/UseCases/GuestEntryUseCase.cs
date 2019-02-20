using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public sealed class GuestEntryUseCase : IGuestEntryUseCase
    {
        private readonly IGuestEntryRepository _guestEntryRepository;

        public GuestEntryUseCase(IGuestEntryRepository guestEntryRepository)
        {
            _guestEntryRepository = guestEntryRepository;
        }

        public async Task<bool> Handle(GuestEntryRequest message, IOutputPort<GuestEntryResponse> outputPort)
        {
            var response = await _guestEntryRepository.Create(message.GuestId, message.FirstName, message.LastName,message.Email, message.StartDate, message.EndDate, message.ClientId);
            outputPort.Handle(response.Success ? new GuestEntryResponse(response.Id, true) : new GuestEntryResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
