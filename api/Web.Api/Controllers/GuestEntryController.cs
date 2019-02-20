using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Presenters;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiUser")]
    public class GuestEntryController : ControllerBase
    {
        private readonly IGuestEntryUseCase _guestEntryUseCase;
        private readonly IGuestEntryGetUseCase _guestEntryGetUseCase;
        private readonly GuestEntryPresenter _guestEntryPresenter;

        public GuestEntryController(IGuestEntryUseCase guestEntryUseCase, IGuestEntryGetUseCase guestEntryGetUseCase, GuestEntryPresenter guestEntryPresenter)
        {
            _guestEntryUseCase = guestEntryUseCase;
            _guestEntryGetUseCase = guestEntryGetUseCase;
            _guestEntryPresenter = guestEntryPresenter;
        }

        // POST api/guestentry
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.GuestEntryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _guestEntryUseCase.Handle(new GuestEntryRequest(request.GuestId, request.FirstName, request.LastName, request.Email, request.StartDate, request.EndDate, request.ClientId), _guestEntryPresenter);
            return _guestEntryPresenter.ContentResult;
        }

        // GET api/guestentry
        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _guestEntryGetUseCase.Handle(new GuestEntryRequest(id), _guestEntryPresenter);
            return _guestEntryPresenter.ContentResult;
        }
    }
}