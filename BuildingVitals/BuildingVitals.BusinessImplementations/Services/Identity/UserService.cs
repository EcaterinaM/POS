using System;
using System.Threading.Tasks;
using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Models.Identity;
using BuildingVitals.BusinessContracts.Services;
using BuildingVitals.BusinessContracts.Services.Identity;
using BuildingVitals.Common.Constants;
using BuildingVitals.DataAccessContracts.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace BuildingVitals.BusinessImplementations.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IMapper _serviceMapper;
        private readonly IApartmentService _apartmentService;

        public UserService(UserManager<User> userManager, 
            RoleManager<IdentityRole<Guid>> roleManager, 
            IMapper serviceMapper,
            IApartmentService apartmentService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _serviceMapper = serviceMapper;
            _apartmentService = apartmentService;
        }

        public async Task<UserIdentityModel> FindByName(string userName)
        {
            return await FindUser(userName);
        }

        public async Task<UserIdentityModel> Find(string userName, string password)
        {
            return await FindUser(userName, password);
        }

        public async Task<IdentityResult> AddRefreshToken(string userName, string loginProvider, string value)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return await _userManager.SetAuthenticationTokenAsync(user, loginProvider, UserIdentityConstants.TokenName, value);
        }

        public async Task<IdentityResult> UpdateRefreshToken(TokensAuthenticationModel tokensAuthenticationModel,
            string userName, string newValue)
        {
            var user = await GetUserByValidToken(tokensAuthenticationModel, userName);
            return await _userManager.SetAuthenticationTokenAsync(user,
                tokensAuthenticationModel.LoginProvider, UserIdentityConstants.TokenName, newValue);
        }

        public async Task<IdentityResult> RemoveRefreshToken(TokensAuthenticationModel tokensAuthenticationModel,
            string userName)
        {
            var user = await GetUserByValidToken(tokensAuthenticationModel, userName);
            return await _userManager.RemoveAuthenticationTokenAsync(user, tokensAuthenticationModel.LoginProvider,
                UserIdentityConstants.TokenName);
        }

        public async Task AddAdmin(AddUserModel userModel)
        {
            await _userManager.AddAdmin(_serviceMapper, userModel);
        }

        public async Task AddTenant(AddUserWithApartmentModel userWithApartmentModel)
        {
            var userModel = new AddUserModel(userWithApartmentModel);
            var addedUserId = await _userManager.AddTenant(_serviceMapper, userModel);

            var apartment = new ApartmentModel(userWithApartmentModel, addedUserId);
            _apartmentService.AddApartment(apartment);
        }

        private async Task<User> GetUserByValidToken(TokensAuthenticationModel tokensAuthenticationModel,
            string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var existingToken = await _userManager.GetAuthenticationTokenAsync(user,
                tokensAuthenticationModel.LoginProvider, UserIdentityConstants.TokenName);
            if (existingToken != tokensAuthenticationModel.RefreshToken)
            {
                throw new UnauthorizedAccessException();
            }

            return user;
        }

        private async Task<UserIdentityModel> FindUser(string userName, string password = null)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || (password != null && !await _userManager.CheckPasswordAsync(user, password)))
                return null;

            var userModel = _serviceMapper.Map<UserIdentityModel>(user);
            userModel.Roles = await _userManager.GetRolesAsync(user);
            return userModel;
        }
    }
}
