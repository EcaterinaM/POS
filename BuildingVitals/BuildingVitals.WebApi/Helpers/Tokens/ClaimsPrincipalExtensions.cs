using System.Linq;
using System.Security.Claims;

namespace BuildingVitals.WebApi.Helpers.Tokens
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            return principal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        }
    }
}
