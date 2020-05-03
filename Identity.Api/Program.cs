using System;
using IdentityServer4.EntityFramework.DbContexts;
using MicroBank.Identity.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Identity.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            // For seeding (this will also execute migrations)
            Seed(host);

            host.Run();
        }

        private static void Seed(IHost host)
        {

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var appIdentityDbContext = services.GetRequiredService<AppIdentityDbContext>();
                AppIdentityDbContextSeed.SeedAsync(appIdentityDbContext).Wait();
                var persistedGrantDbContext = services.GetRequiredService<PersistedGrantDbContext>();
                PersistedGrantDbContextSeed.SeedAsync(persistedGrantDbContext).Wait();
            }
            catch (Exception ex)
            {
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
