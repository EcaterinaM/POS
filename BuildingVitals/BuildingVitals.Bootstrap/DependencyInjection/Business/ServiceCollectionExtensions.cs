using BuildingVitals.BusinessContracts.Services.Identity;
using BuildingVitals.BusinessImplementations.Services.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingVitals.Bootstrap.DependencyInjection.Business
{
    internal static class ServiceCollectionExtensions
    {
        internal static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
