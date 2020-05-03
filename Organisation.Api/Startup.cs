using MediatR;
using MicroBank.Common.Identity;
using MicroBank.Common.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Organisation.Core.Interfaces.Repository;
using Organisation.Core.Interfaces.Service;
using Organisation.Core.Services;
using Organisation.Infrastructure.Data;
using Organisation.Infrastructure.Repository;

namespace Organisation.Api
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
            services.AddDbContext<OrganisationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("OrganisationDbConnection"));
            });

            services.AddHttpContextAccessor();
            services.AddScoped(typeof(ClaimsPrincipalUtil)); // to get values from claims
            services.AddScoped(typeof(IEfRepository<,>), typeof(EfRepository<,>));
            services.AddControllers();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration["Identity:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.Audience = Configuration["Identity:Audience"];
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Organization Microservice", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));

            services.AddScoped<DbContext, OrganisationDbContext>();
            services.AddScoped(typeof(IOfficeRepository), typeof(OfficeRepository));
            services.AddScoped(typeof(IOfficeService), typeof(OfficeService));
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Organization Microservice V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
