using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BuildingVitals.WebApi.Helpers.Tokens
{
    public class TokenSettings
    {
        public TokenValidationParameters TokenValidationParameters { get; private set; }

        public TokenValidationParameters ExpiredTokenValidationParameters { get; private set; }

        public TokenSettings(IConfiguration configuration)
        {
            TokenValidationParameters = GetTokenValidationParameters(configuration);
            ExpiredTokenValidationParameters = GetTokenValidationParameters(configuration, false);
        }

        private TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration, bool validateLifetime = true)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration["AppSettings:Issuer"],

                ValidateAudience = false,
                ValidAudience = configuration["AppSettings:Audience"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSymmetricSecurityKey(configuration),

                RequireExpirationTime = validateLifetime,
                ValidateLifetime = validateLifetime,
                ClockSkew = TimeSpan.Zero
            };
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey(IConfiguration configuration)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Secret"]));
        }
    }
}