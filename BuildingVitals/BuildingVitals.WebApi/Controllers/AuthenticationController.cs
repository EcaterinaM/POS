using System.Threading.Tasks;
using BuildingVitals.BusinessContracts.Models.Identity;
using BuildingVitals.WebApi.Helpers.Tokens;
using BuildingVitals.WebApi.Helpers.Tokens.AccessToken;
using BuildingVitals.WebApi.Helpers.Tokens.RefreshToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingVitals.WebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TokenHelper _tokenHelper;
        private readonly RefreshTokenHelper _refreshTokenHelper;

        public AuthenticationController(TokenHelper tokenHelper, RefreshTokenHelper refreshTokenHelper)
        {
            _tokenHelper = tokenHelper;
            _refreshTokenHelper = refreshTokenHelper;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody]CredentialsModel credentials)
        {
            var response = await (await new TokensAuthenticationModel()
                    .AddAccessToken(credentials, _tokenHelper))
                .AddRefreshTokenFields(credentials.UserName, _refreshTokenHelper);

            return Ok(response);
        }

        [HttpPut("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody]TokensAuthenticationModel tokensAuthenticationModel)
        {
            var userName = _tokenHelper.GetUserNameFromExpiredToken(tokensAuthenticationModel.AccessToken);

            var response = await (await tokensAuthenticationModel
                    .AddAccessToken(userName, _tokenHelper))
                .UpdateRefreshToken(userName, _refreshTokenHelper);

            return Ok(response);
        }

        [HttpPut("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody]TokensAuthenticationModel tokensAuthenticationModel)
        {
            await _refreshTokenHelper.Remove(tokensAuthenticationModel,
                _tokenHelper.GetUserNameFromExpiredToken(tokensAuthenticationModel.AccessToken), User);

            return Ok();
        }
    }
}
