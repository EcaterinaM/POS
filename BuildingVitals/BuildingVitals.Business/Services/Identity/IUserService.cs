using System.Threading.Tasks;
using BuildingVitals.BusinessContracts.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace BuildingVitals.BusinessContracts.Services.Identity
{
    /// <summary>
    /// The service interface for the identity user.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Finds the user by his username asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>UserModel</returns>
        Task<UserModel> FindByName(string username);

        /// <summary>
        /// Checks the password asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>True the user model found by username and password in the database.</returns>
        Task<UserModel> Find(string username, string password);

        /// <summary>
        /// Adds the refresh token for a user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="value">The value.</param>
        /// <returns>The identity result</returns>
        Task<IdentityResult> AddRefreshToken(string userName, string loginProvider, string value);

        /// <summary>
        /// Updates the refresh token.
        /// </summary>
        /// <param name="tokensAuthenticationModel">The tokens authentication model.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="newValue">The new value.</param>
        /// <returns>The identity result</returns>
        Task<IdentityResult> UpdateRefreshToken(TokensAuthenticationModel tokensAuthenticationModel,
            string userName, string newValue);

        /// <summary>
        /// Removes the refresh token.
        /// </summary>
        /// <param name="tokensAuthenticationModel">The tokens authentication model.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The identity result.</returns>
        Task<IdentityResult> RemoveRefreshToken(TokensAuthenticationModel tokensAuthenticationModel,
            string userName);

    }
}
