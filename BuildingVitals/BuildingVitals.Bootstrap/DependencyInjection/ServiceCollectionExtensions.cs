using BuildingVitals.Bootstrap.DependencyInjection.Business;
using BuildingVitals.Bootstrap.DependencyInjection.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingVitals.Bootstrap.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddIoc(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddBusiness();
        }
    }
}
