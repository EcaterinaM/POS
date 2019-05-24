using System.Threading.Tasks;
using BuildingVitals.DataAccessContracts.Entities.Identity;
using BuildingVitals.DataAccessContracts.Repositories;
using BuildingVitals.DataAccessImplementations.Context;
using Microsoft.AspNetCore.Identity;

namespace BuildingVitals.DataAccessImplementations.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext Context;

        private readonly UserManager<User> _userManager;

        public UserRepository(AppDbContext context, 
            UserManager<User> userManager)
        {
            Context = context;
            _userManager = userManager;
        }

        public async Task<User> EditUser(User user)
        {
            await _userManager.UpdateAsync(user);
            await Context.SaveChangesAsync();
            return await _userManager.FindByNameAsync(user.UserName);
        }
    }
}
