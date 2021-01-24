using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxService.Helpers;

namespace TaxService.Extensions
{    
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Extension for CORs enablment and policy.
        /// </summary>
        public static void AddCustomCors(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        /// <summary>
        /// Extension for provding strongly typed access to AppSettings section in appsettings.json.
        /// </summary>
        public static void AddAppSettingsOptions(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsSection = config.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
        }
    }
}
