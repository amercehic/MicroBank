using Microsoft.EntityFrameworkCore;
using Organisation.Core.Entities;

namespace Organisation.Infrastructure.Data
{
    public class OrganisationDbContext : DbContext
    {
        public OrganisationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Office>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<StaffMember>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public DbSet<Office> Offices { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
    }
}
