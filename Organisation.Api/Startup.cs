using MediatR;
using MicroBank.Common.ExceptionHandler;
using MicroBank.Common.Identity;
using MicroBank.Common.Repository;
using MicroBank.EventBus.Bus;
using MicroBank.EventBusServiceBus.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Organisation.Core.Integrations.EventBus.CommandHandlers;
using Organisation.Core.Integrations.EventBus.Commands;
using Organisation.Core.Integrations.Services.ClientApi;
using Organisation.Core.Interfaces.Repository;
using Organisation.Core.Interfaces.Service;
using Organisation.Core.Services;
using Organisation.Infrastructure.Data;
using Organisation.Infrastructure.Integrations.Services;
using Organisation.Infrastructure.Repository;
using System;

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
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddDbContext<OrganisationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("OrganisationDbConnection"));
            });

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

            services.AddHttpContextAccessor();
            services.AddScoped(typeof(ClaimsPrincipalUtil)); // to get values from claims
            services.AddScoped(typeof(IEfRepository<,>), typeof(EfRepository<,>));
            services.AddTransient<HttpClientExceptionHandler>(); // handle PMToolsException from another service
            services.AddHeaderPropagation(s => s.Headers.Add("Authorization")); // forward authorizatin header to api's
            services.AddScoped<DbContext, OrganisationDbContext>();

            services.AddHttpClient<IClientApiService, ClientApiService>("ClientApiService", c =>
            {
                c.BaseAddress = new Uri(Configuration["ServiceUrls:ClientApi"]);
            }).AddHeaderPropagation().AddHttpMessageHandler<HttpClientExceptionHandler>();



            services.AddScoped(typeof(IOfficeRepository), typeof(OfficeRepository));
            services.AddScoped(typeof(IOfficeService), typeof(OfficeService));

            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
            services.AddTransient<IRequestHandler<CreateUpdateStaffMemberCommand, bool>, UpdateStaffMemberCommandHandler>();

            services.AddScoped(typeof(IStaffMemberRepository), typeof(StaffMemberRepository));
            services.AddScoped(typeof(IStaffMemberService), typeof(StaffMemberService));
            services.AddMediatR(typeof(Startup));

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
            app.UseHeaderPropagation();

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
