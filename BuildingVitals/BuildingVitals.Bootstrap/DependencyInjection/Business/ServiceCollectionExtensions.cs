using BuildingVitals.BusinessContracts.Services;
using BuildingVitals.BusinessContracts.Services.Identity;
using BuildingVitals.BusinessImplementations.Mail;
using BuildingVitals.BusinessImplementations.Services;
using BuildingVitals.BusinessImplementations.Services.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingVitals.Bootstrap.DependencyInjection.Business
{
    internal static class ServiceCollectionExtensions
    {
        internal static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<ISensorService, SensorService>();
            services.AddScoped<IMetricService, MetricService>();
            services.AddScoped<IMailService, MailService>();
        }
    }
}
