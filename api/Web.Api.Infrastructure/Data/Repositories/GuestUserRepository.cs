using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Helpers;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Specifications;
using Web.Api.Infrastructure.Identity;


namespace Web.Api.Infrastructure.Data.Repositories
{
    internal sealed class GuestUserRepository : EfRepository<OdcGuestUser>, IGuestUserRepository
    {
        private readonly IMapper _mapper;
        UserManager<AppUser> _userManager;
        private readonly ApiCustomValues _apiCustomValues;

        public GuestUserRepository(IOptions<ApiCustomValues> apiCustomValues, UserManager<AppUser> userManager, AppDbContext appDbContext, IMapper mapper) : base(appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _apiCustomValues = apiCustomValues.Value;
        }

        public async Task<CreateUserResponse> Create(Guid key, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId)
        {
            try
            {
                var guestUser = new OdcGuestUser(firstName, lastName, email, startDate, endDate, key, false, false, null, null, clientId, _apiCustomValues.CurrentDateTime);
                _appDbContext.OdcGuestUsers.Add(guestUser);
                var guestId = await _appDbContext.SaveChangesAsync();
                return new CreateUserResponse(guestId.ToString(), true, null);
            }
            catch (Exception ex)
            {
                return new CreateUserResponse(null, false, new List<Error>() { new Error(ex.Message, ex.StackTrace) });
            }
        }

        public async Task<EditUserResponse> Update(Guid key, Guid guestId, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId)
        {
            try
            {
                if (_appDbContext.OdcGuestUsers.Any(x => x.Id == guestId))
                {
                    var guestUser = _appDbContext.OdcGuestUsers.SingleOrDefault(x => x.Id == guestId);

                    var finalUser = new OdcGuestUser(guestUser.Id, firstName, lastName, email, startDate, endDate, key, guestUser.IsEmailSent, guestUser.IsActive, guestUser.ActivationDate, guestUser.DeactivationDate, clientId, guestUser.Created);
                    _appDbContext.Entry(guestUser).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

                    _appDbContext.OdcGuestUsers.Update(finalUser);
                    await _appDbContext.SaveChangesAsync();
                    return new EditUserResponse(guestId.ToString(), true, null);
                }
                else
                {
                    return new EditUserResponse(null, false, new List<Error>() { new Error("400", "Bad Request") });
                }
            }
            catch (Exception ex)
            {
                return new EditUserResponse(null, false, new List<Error>() { new Error(ex.Message, ex.StackTrace) });
            }
        }

        public async Task<DeleteUserResponse> Delete(Guid guestId)
        {
            try
            {
                if (_appDbContext.OdcGuestUsers.Any(x => x.Id == guestId))
                {
                    _appDbContext.OdcGuestUsers.Remove(_appDbContext.OdcGuestUsers.SingleOrDefault(x => x.Id == guestId));
                    await _appDbContext.SaveChangesAsync();
                    return new DeleteUserResponse(guestId.ToString(), true, null);
                }
                else
                {
                    return new DeleteUserResponse(null, false, new List<Error>() { new Error("400", "Bad Request") });
                }
            }
            catch (Exception ex)
            {
                return new DeleteUserResponse(null, false, new List<Error>() { new Error(ex.Message, ex.StackTrace) });
            }
        }

        public Task<List<OdcGuestUser>> GetAll()
        {
            return _appDbContext.OdcGuestUsers.ToListAsync();
        }
    }
}