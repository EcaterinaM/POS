using BuildingVitals.WebApi.Helpers.Tokens;
using BuildingVitals.WebApi.Helpers.Tokens.AccessToken;
using BuildingVitals.WebApi.Helpers.Tokens.RefreshToken;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingVitals.WebApi.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiIoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddSingleton<TokenSettings, TokenSettings>();
            services.AddScoped<TokenHelper, TokenHelper>();
            services.AddScoped<RefreshTokenHelper, RefreshTokenHelper>();
        }
    }
}
