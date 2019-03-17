using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.Common.Constants;
using BuildingVitals.DataAccessContracts.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace BuildingVitals.BusinessImplementations.Services.Identity
{
    public static class UserManagerExtensions
    {
        public static async Task AddAdmin(this UserManager<User> userManager, IMapper serviceMapper, AddUserModel userModel)
        {
            var user = serviceMapper.Map<User>(userModel);
            user.Id = Guid.NewGuid();

            await userManager.CreateAsync(user, userModel.Password);
            await userManager.AddToRoleAsync(user, RoleConstants.Admin);
        }

        public static async Task AddTenant(this UserManager<User> userManager, IMapper serviceMapper, AddUserModel userModel)
        {
            var user = serviceMapper.Map<User>(userModel);
            user.Id = Guid.NewGuid();

            await userManager.CreateAsync(user, userModel.Password);
            await userManager.AddToRoleAsync(user, RoleConstants.Tenant);
        }
    }
}
