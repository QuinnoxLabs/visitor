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
    public class GuestController : ControllerBase
    {
        private readonly IGuestUserGetUseCase _guestUserGetUseCase;
        private readonly IGuestUserUseCase _guestUserUseCase;
        private readonly IGuestEditUserUseCase _guestEditUserUseCase;
        private readonly IGuestDeleteUserUseCase _guestDeleteUserUseCase;
        private readonly GuestUserPresenter _guestUserPresenter;

        public GuestController(IGuestUserUseCase guestUserUseCase, IGuestEditUserUseCase guestEditUserUseCase, IGuestDeleteUserUseCase guestDeleteUserUseCase, IGuestUserGetUseCase guestUserGetUseCase, GuestUserPresenter guestUserPresenter)
        {
            _guestUserUseCase = guestUserUseCase;
            _guestEditUserUseCase = guestEditUserUseCase;
            _guestDeleteUserUseCase = guestDeleteUserUseCase;
            _guestUserPresenter = guestUserPresenter;
            _guestUserGetUseCase = guestUserGetUseCase;
        }

        // POST api/guest
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.GuestUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _guestUserUseCase.Handle(new GuestUserRequest(request.Key, request.FirstName, request.LastName, request.Email, request.StartDate, request.EndDate, request.ClientId), _guestUserPresenter);
            return _guestUserPresenter.ContentResult;
        }

        // PUT api/guest
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] Models.Request.GuestUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _guestEditUserUseCase.Handle(new GuestUserRequest(request.Key, id, request.FirstName, request.LastName, request.Email, request.StartDate, request.EndDate, request.ClientId), _guestUserPresenter);
            return _guestUserPresenter.ContentResult;
        }

        // DELETE api/guest
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _guestDeleteUserUseCase.Handle(new GuestUserRequest(id), _guestUserPresenter);
            return _guestUserPresenter.ContentResult;
        }

        // DELETE api/guest
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _guestUserGetUseCase.Handle(new GuestUserRequest(), _guestUserPresenter);
            return _guestUserPresenter.ContentResult;
        }
    }
}