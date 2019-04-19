using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;
using BuildingVitals.DataAccessImplementations.Context;
using BuildingVitals.DataAccessImplementations.Repositories.Base;

namespace BuildingVitals.DataAccessImplementations.Repositories
{
    public class BuildingRepository: BaseRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
