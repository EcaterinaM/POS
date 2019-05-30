using System.Threading.Tasks;
using BuildingVitals.BusinessContracts.SensorJob;
using Hangfire;
using Microsoft.AspNetCore.Http;

namespace BuildingVitals.WebApi.Middlewares
{
    public class SensorJobMiddleware
    {
        private readonly RequestDelegate _next;

        public SensorJobMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var cronSection = "2 * * * *";
            RecurringJob.AddOrUpdate<ISensorJob>(x => x.AddSensorData(), cronSection);
            return _next(context);
        }
    }
}
