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
                mc.AddProfile(new ApartmentProfile());
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new BuildingProfile());
                mc.AddProfile(new ApartmentProfile());
                mc.AddProfile(new SensorProfile());
                mc.AddProfile(new ApartmentSensorProfile());
                mc.AddProfile(new MetricProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
