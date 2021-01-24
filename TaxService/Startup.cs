using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxService.Extensions;
using TaxService.Helpers;
using TaxService.MappingProfiles;
using TaxService.Middleware;
using TaxService.Services.Interfaces;
using TaxService.Services;

namespace TaxService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomCors("AllowAllOrigins");

            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSwaggerGen();

            services.AddHealthChecks();

            //Register different ITaxCalculatorService services here, then decided which service to use at runtime depending on API consumer.
            services.AddScoped<ITaxCalculatorService, TaxJarCalculatorService>();
            //services.AddScoped<ITaxCalculatorService, AnotherCalculatorService>();

            services.AddSingleton<ModelValidationAttribute>();

            services.AddAutoMapper(typeof(DefaultMappingProfile));

            services.AddAppSettingsOptions(this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            //Add middleware for handling uncaught exception at global level.
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            //Add an API endpoint /health for healthcheck monitoring
            app.UseHealthChecks("/health", new HealthCheckOptions { ResponseWriter = ResponseWriters.HealthJsonResponseWriter });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }        
    }
}
