using Account.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Core.Entities.MainAccount>().HasIndex(s => s.ClientId);
            builder.Entity<Client>()
                    .HasMany(c => c.Accounts)
                    .WithOne(e => e.Client);

            builder.Entity<Client>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<Product>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<Core.Entities.MainAccount>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<Currency>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public DbSet<Core.Entities.MainAccount> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
