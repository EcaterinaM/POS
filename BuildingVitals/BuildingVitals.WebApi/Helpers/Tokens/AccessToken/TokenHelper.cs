using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnteaNL.CustomerSatisfaction.Common.Exceptions;
using BuildingVitals.BusinessContracts.Models.Identity;
using BuildingVitals.BusinessContracts.Services.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BuildingVitals.WebApi.Helpers.Tokens.AccessToken
{
    public partial class TokenHelper
    {
        private readonly IUserService _userService;
        private readonly TokenSettings _tokenSettings;

        public TokenHelper(IUserService userService, TokenSettings tokenSettings)
        {
            _userService = userService;
            _tokenSettings = tokenSettings;
        }

        public async Task<string> GenerateToken(string userName, string password)
        {
            var claims = await GetIdentityClaims(userName, password);
            return GenerateToken(claims);
        }

        public async Task<IEnumerable<Claim>> GetIdentityClaims(string userName, string password)
        {
            var user = await _userService.Find(userName, password);
            if (user == null) throw new UnauthorizedAccessException(ExceptionMessages.InvalidUsernameOrPassword);

            return await Task.FromResult(GenerateIdentityClaims(user));
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = _tokenSettings.TokenValidationParameters.IssuerSigningKey;
            var issuer = _tokenSettings.TokenValidationParameters.ValidIssuer;
            var audience = _tokenSettings.TokenValidationParameters.ValidAudience;

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private IEnumerable<Claim> GenerateIdentityClaims(UserIdentityModel userIdentity)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userIdentity.Id.ToString()),
                new Claim(ClaimTypes.Name, userIdentity.UserName)
            };
            claims.AddRange(userIdentity.Roles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            return claims;
        }
    }
}
