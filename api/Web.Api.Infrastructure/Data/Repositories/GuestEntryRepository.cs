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
    internal sealed class GuestEntryRepository : EfRepository<OdcGuestEntry>, IGuestEntryRepository
    {
        private readonly IMapper _mapper;
        UserManager<AppUser> _userManager;
        private readonly ApiCustomValues _apiCustomValues;

        public GuestEntryRepository(IOptions<ApiCustomValues> apiCustomValues, UserManager<AppUser> userManager, AppDbContext appDbContext, IMapper mapper) : base(appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _apiCustomValues = apiCustomValues.Value;
        }

        public async Task<CreateUserResponse> Create(Guid guestId, string firstName, string lastName, string email, DateTime startDate, DateTime endDate, string clientId)
        {
            try
            {
                if (_appDbContext.OdcGuestUsers.Any(x => x.Id == guestId && x.Email == email && x.FirstName == firstName && x.LastName == lastName && x.StartDate.ToShortDateString() == startDate.ToShortDateString() && x.EndDate.ToShortDateString() == endDate.ToShortDateString()))
                {
                    var guestUser = _appDbContext.OdcGuestUsers.FirstOrDefault(x => x.Id == guestId && x.Email == email && x.FirstName == firstName && x.LastName == lastName && x.StartDate.ToShortDateString() == startDate.ToShortDateString() && x.EndDate.ToShortDateString() == endDate.ToShortDateString());
                    _appDbContext.OdcGuestEntries.Add(new OdcGuestEntry(guestUser.Id, _apiCustomValues.CurrentDateTime));
                    var guestEntryId = await _appDbContext.SaveChangesAsync();
                    if (guestUser.IsActive == false)
                    {
                        var finalUser = new OdcGuestUser(guestUser, true, _apiCustomValues.CurrentDateTime);
                        _appDbContext.Entry(guestUser).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        _appDbContext.OdcGuestUsers.Update(finalUser);
                        await _appDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var finalUser = new OdcGuestUser(guestUser, _apiCustomValues.CurrentDateTime);
                        _appDbContext.Entry(guestUser).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        _appDbContext.OdcGuestUsers.Update(finalUser);
                        await _appDbContext.SaveChangesAsync();
                    }
                    return new CreateUserResponse(guestEntryId.ToString(), true, null);
                }
                else
                {
                    return new CreateUserResponse(null, false, new List<Error>() { new Error("400", "Bad Request") });
                }
            }
            catch (Exception ex)
            {
                return new CreateUserResponse(null, false, new List<Error>() { new Error(ex.Message, ex.StackTrace) });
            }
        }

        public Task<List<OdcGuestEntry>> GetByGuid(Guid guestId)
        {
            return _appDbContext.OdcGuestEntries.Where(x => x.OdcGuestUserId == guestId).ToListAsync();
        }
    }
}