using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Helpers;
using Web.Api.Core.Shared;


namespace Web.Api.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly ApiCustomValues _apiCustomValues;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);

            modelBuilder.Entity<OdcGuestUser>()
            .HasOne(p => p.User)
            .WithMany(b => b.OdcGuestUsers)
            .HasForeignKey(p => p.CreatedBy)
            .HasConstraintName("ForeignKey_OdcGuestUser_UserId");

            modelBuilder.Entity<OdcGuestEntry>()
            .HasOne(p => p.OdcGuestUser)
            .WithMany(b => b.GuestEntries)
            .HasForeignKey(p => p.OdcGuestUserId)
            .HasConstraintName("ForeignKey_OdcGuestEntry_OdcGuestUserId");

        }

        public void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(User.RefreshTokens));
            //EF access the RefreshTokens collection property through its backing field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore(b => b.Email);
            builder.Ignore(b => b.PasswordHash);
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<OdcGuestUser> OdcGuestUsers { get; set; }

        public DbSet<OdcGuestEntry> OdcGuestEntries { get; set; }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                }
                ((BaseEntity)entry.Entity).Modified = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            }
        }
    }
}


