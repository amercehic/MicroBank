using Microsoft.EntityFrameworkCore;

namespace Card.Infrastructure.Data
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Core.Entities.Account>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<Core.Entities.Card>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<Core.Entities.Currency>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public DbSet<Core.Entities.Card> Cards { get; set; }
        public DbSet<Core.Entities.Account> Accounts { get; set; }
        public DbSet<Core.Entities.Currency> Currencies { get; set; }
    }
}
