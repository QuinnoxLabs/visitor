using Microsoft.EntityFrameworkCore;
using Web.Api.Infrastructure.Shared;

namespace Web.Api.Infrastructure.Identity
{
    /// <summary>
    /// Allows the entity framework tools to generate migrations directly from our infrastructure class library
    /// </summary>
    public class AppIdentityDbContextFactory : DesignTimeDbContextFactoryBase<AppIdentityDbContext>
    {
        protected override AppIdentityDbContext CreateNewInstance(DbContextOptions<AppIdentityDbContext> options)
        {
            return new AppIdentityDbContext(options);
        }
    }
}
