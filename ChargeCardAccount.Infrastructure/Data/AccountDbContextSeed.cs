using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Account.Infrastructure.Data
{
    public class AccountDbContextSeed
    {
        public static async Task SeedAsync(AccountDbContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {

            int retryForAvailability = retry.Value;
            try
            {
#pragma warning disable CA1062 // Validate arguments of public methods
                context.Database.Migrate(); // this needs to apply migrations if they not exists in the database
#pragma warning restore CA1062 // Validate arguments of public methods

                // await context.SaveChangesAsync(); // Use this after put some data in database
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AccountDbContext>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability).ConfigureAwait(false);
                }
            }
        }
    }
}
