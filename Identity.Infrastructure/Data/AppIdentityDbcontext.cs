using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicroBank.Identity.Infrastructure.Context
{
    /// <summary>
    /// Db context class
    /// For migrations:
    /// 1. Navigate console to Infrastructure project
    /// 2. Create migration with command: dotnet ef migrations add {NameOfMigration} -s ../Identity.Api -o ./Migrations/AppIdentityDb --context AppIdentityDbContext
    /// 3. Update database with command: dotnet ef database update -s ../Identity.Api --context AppIdentityDbContext
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
