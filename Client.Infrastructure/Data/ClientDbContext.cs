using Client.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Client.Infrastructure.Data
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Core.Entities.Client.RejectedClientApplication>().HasIndex(s => s.ClientId);
            builder.Entity<Core.Entities.Client.Document>().HasIndex(s => s.ClientId);

            builder.Entity<Core.Entities.Client.Document>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<Core.Entities.Client.Client>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<Core.Entities.Client.RejectedClientApplication>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public DbSet<Core.Entities.Client.Client> Clients { get; set; }
        public DbSet<Core.Entities.Client.Document> Documents { get; set; }
        public DbSet<Core.Entities.Client.RejectedClientApplication> RejectedClientApplications { get; set; }
        public DbSet<Core.Entities.Staff.StaffMember> StaffMembers { get; set; }
    }
}
