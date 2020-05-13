using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Document.Core.Intefaces.Repository;
using Document.Core.Intefaces.Services;
using Document.Core.Models.Options;
using Document.Core.Services;
using Document.Infrastructure.Repository;
using MicroBank.Common.ExceptionHandler;
using MicroBank.Common.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Document.Api
{
    public class Startup
    {
        public string ServiceName { get; set; } = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration["Identity:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.Audience = Configuration["Identity:Audience"];
                });


            services.Configure<AzureStorageOptions>(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("AzureStorage");
            });

            services.Configure<ImageSettings>((settings) =>
            {
                Configuration.GetSection("ImageSettings").Bind(settings);
            });

            // Common services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ServiceName, Version = "v1" });
            });
            services.AddApplicationInsightsTelemetry();
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(ClaimsPrincipalUtil)); // to get values from claims
            // End common services

            services.AddScoped<IAzureStorageRepository, AzureStorageRepository>();
            services.AddScoped<IImageService, ImageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ServiceName} API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(Configuration["CorsPolicy"]);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
