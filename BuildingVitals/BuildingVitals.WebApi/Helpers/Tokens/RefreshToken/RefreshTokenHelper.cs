using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AnteaNL.CustomerSatisfaction.Common.Exceptions;
using BuildingVitals.BusinessContracts.Models.Identity;
using BuildingVitals.BusinessContracts.Services.Identity;
using Microsoft.AspNetCore.Identity;

namespace BuildingVitals.WebApi.Helpers.Tokens.RefreshToken
{
    public class RefreshTokenHelper
    {
        private readonly IUserService _userService;

        public RefreshTokenHelper(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Add(string userName, string loginProvider)
        {
            var generatedRefreshToken = Generate();
            ValidateResult( 
                await _userService.AddRefreshToken(userName, loginProvider, generatedRefreshToken));

            return generatedRefreshToken;
        }

        public async Task<string> Update(TokensAuthenticationModel tokensAuthenticationModel, string userName)
        {
            var generatedRefreshToken = Generate();
            ValidateResult(
                await _userService.UpdateRefreshToken(tokensAuthenticationModel, userName, generatedRefreshToken));

            return generatedRefreshToken;
        }

        public async Task Remove(TokensAuthenticationModel tokensAuthenticationModel, string userName, ClaimsPrincipal principal)
        {
            if (userName == null || userName != principal.GetLoggedInUserName())
            {
                throw new ForbiddenException(ExceptionMessages.ForbiddenException);
            }
            
            ValidateResult(
                await _userService.RemoveRefreshToken(tokensAuthenticationModel, userName));
        }

        private void ValidateResult(IdentityResult result)
        {
            if (result == null || !result.Succeeded)
            {
                throw new Exception();
            }
        }

        private string Generate()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}