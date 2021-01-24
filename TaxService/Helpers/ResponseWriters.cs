using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TaxService.Helpers
{
    /// <summary>
    /// Response writer for handling /health endpoint.
    /// </summary>
    public static class ResponseWriters
    {
        public static async Task HealthJsonResponseWriter(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = "application/json";
            var body = new
            {
                Status = report.Status.ToString(),
                Duration = report.TotalDuration.ToString()
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(body));
        }
    }
}
