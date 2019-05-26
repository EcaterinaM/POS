using System.Threading.Tasks;
using BuildingVitals.DataAccessContracts.Entities.Identity;

namespace BuildingVitals.DataAccessContracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> EditUser(User user);
    }
}
