using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBank.Identity.Infrastructure.Context
{
    public class PersistedGrantDbContextSeed
    {
        public static async Task SeedAsync(PersistedGrantDbContext context, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                context.Database.Migrate(); // this needs to apply migrations if they not exists in the database

                //await context.SaveChangesAsync(); // Use this after put some data in database
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    await SeedAsync(context, retryForAvailability);
                }
            }
        }
    }
}
