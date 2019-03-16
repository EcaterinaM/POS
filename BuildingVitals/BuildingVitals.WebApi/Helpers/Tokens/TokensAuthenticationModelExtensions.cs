using System;
using System.Threading.Tasks;
using BuildingVitals.BusinessContracts.Models.Identity;
using BuildingVitals.WebApi.Helpers.Tokens.AccessToken;
using BuildingVitals.WebApi.Helpers.Tokens.RefreshToken;

namespace BuildingVitals.WebApi.Helpers.Tokens
{
    public static class TokensAuthenticationModelExtensions
    {
        public static async Task<TokensAuthenticationModel> AddAccessToken(this TokensAuthenticationModel tokensAuthenticationModel,
            CredentialsModel credentials,
            TokenHelper tokenHelper)
        {
            tokensAuthenticationModel.AccessToken =
                await tokenHelper.GenerateToken(credentials.UserName, credentials.Password);

            return tokensAuthenticationModel;
        }

        public static async Task<TokensAuthenticationModel> AddAccessToken(
            this TokensAuthenticationModel tokensAuthenticationModel, string userName, TokenHelper tokenHelper)
        {
            tokensAuthenticationModel.AccessToken = await tokenHelper.GenerateToken(userName);
            return tokensAuthenticationModel;
        }

        public static async Task<TokensAuthenticationModel> AddRefreshTokenFields(
            this TokensAuthenticationModel tokensAuthenticationModel,
            string userName,
            RefreshTokenHelper refreshTokenHelper)
        {
            var loginProvider = Guid.NewGuid().ToString();

            tokensAuthenticationModel.LoginProvider = loginProvider;
            tokensAuthenticationModel.RefreshToken = await refreshTokenHelper.Add(userName, loginProvider);
            return tokensAuthenticationModel;
        }

        public static async Task<TokensAuthenticationModel> UpdateRefreshToken(
            this TokensAuthenticationModel tokensAuthenticationModel,
            string userName,
            RefreshTokenHelper refreshTokenHelper)
        {
            tokensAuthenticationModel.RefreshToken = await refreshTokenHelper.Update(tokensAuthenticationModel, userName);
            return tokensAuthenticationModel;
        }
    }
}
