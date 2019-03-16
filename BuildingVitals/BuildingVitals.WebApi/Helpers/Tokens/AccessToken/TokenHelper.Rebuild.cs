using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using AnteaNL.CustomerSatisfaction.Common.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace BuildingVitals.WebApi.Helpers.Tokens.AccessToken
{
    public partial class TokenHelper
    {
        public async Task<string> GenerateToken(string userName)
        {
            var user = await _userService.FindByName(userName);
            var claims = GenerateIdentityClaims(user);
            return GenerateToken(claims);
        }

        public string GetUserNameFromExpiredToken(string token)
        {
            var principal = GetPrincipalFromExpiredToken(token);
            var userName = principal.GetLoggedInUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException(ExceptionMessages.GeneralUnauthorizedException);
            }

            return userName;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(
                    token, _tokenSettings.ExpiredTokenValidationParameters, out SecurityToken securityToken);


                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase))
                    throw new UnauthorizedAccessException(ExceptionMessages.GeneralUnauthorizedException);

                return principal;
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException(ExceptionMessages.GeneralUnauthorizedException);
            }
        }
    }
}
