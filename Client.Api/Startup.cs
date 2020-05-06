using Client.Core.Interfaces.Repository;
using Client.Core.Interfaces.Service;
using Client.Core.Services;
using Client.Infrastructure.Data;
using Client.Infrastructure.Repository;
using MediatR;
using MicroBank.Common.ExceptionHandler;
using MicroBank.Common.Identity;
using MicroBank.Common.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Client.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddDbContext<ClientDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ClientDbConnection"));
            });

            services.AddHttpContextAccessor();
            services.AddScoped(typeof(ClaimsPrincipalUtil)); // to get values from claims
            services.AddScoped(typeof(IEfRepository<,>), typeof(EfRepository<,>));

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration["Identity:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.Audience = Configuration["Identity:Audience"];
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Client Microservice", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));
            services.AddScoped<DbContext, ClientDbContext>();
            services.AddScoped(typeof(IClientApplicationRepository), typeof(ClientApplicationRepository));
            services.AddScoped(typeof(IClientApplicationService), typeof(ClientApplicationService));

            services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));
            services.AddScoped(typeof(IClientService), typeof(ClientService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client Microservice V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
