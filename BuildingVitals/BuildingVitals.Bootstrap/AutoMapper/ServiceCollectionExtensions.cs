using AutoMapper;
using BuildingVitals.BusinessImplementations.Configurations.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingVitals.Bootstrap.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
