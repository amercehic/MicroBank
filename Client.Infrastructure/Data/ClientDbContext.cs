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

            builder.Entity<ClientApplication>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public DbSet<ClientApplication> ClientApplications { get; set; }
    }
}
