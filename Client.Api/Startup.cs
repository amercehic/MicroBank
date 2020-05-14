using Client.Core.Integrations.EventBus.EventHandlers;
using Client.Core.Integrations.EventBus.Events;
using Client.Core.Integrations.Services.OfficeApi;
using Client.Core.Integrations.Services.OrganisationApi;
using Client.Core.Interfaces.Repository;
using Client.Core.Interfaces.Service;
using Client.Core.Services;
using Client.Infrastructure.Data;
using Client.Infrastructure.Integrations.Services;
using Client.Infrastructure.Repository;
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
using System;

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

            services.AddHttpContextAccessor();
            services.AddScoped(typeof(ClaimsPrincipalUtil)); // to get values from claims
            services.AddScoped(typeof(IEfRepository<,>), typeof(EfRepository<,>));
            services.AddTransient<HttpClientExceptionHandler>(); // handle PMToolsException from another service
            services.AddHeaderPropagation(s => s.Headers.Add("Authorization")); // forward authorizatin header to api's

            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<UpdateStaffMemberEventHandler>();
            //Domain Events
            services.AddTransient<IEventHandler<UpdateStaffMemberCreatedEvent>, UpdateStaffMemberEventHandler>();

            services.AddMediatR(typeof(Startup));
            services.AddScoped<DbContext, ClientDbContext>();

            services.AddHttpClient<IOrganisationApiService, OrganisationApiService>("OrganisationApiService", c =>
            {
                c.BaseAddress = new Uri(Configuration["ServiceUrls:OrganisationApi"]);
            }).AddHeaderPropagation().AddHttpMessageHandler<HttpClientExceptionHandler>();

            services.AddScoped(typeof(IRejectedClientApplicationService), typeof(RejectedClientApplicationService));
            services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));
            services.AddScoped(typeof(IClientService), typeof(ClientService));
            services.AddScoped(typeof(IDocumentService), typeof(DocumentService));
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client Microservice V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<UpdateStaffMemberCreatedEvent, UpdateStaffMemberEventHandler>();
        }
    }
}
