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
                mc.AddProfile(new BuildingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
