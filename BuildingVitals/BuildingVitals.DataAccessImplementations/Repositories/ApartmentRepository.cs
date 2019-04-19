using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;
using BuildingVitals.DataAccessImplementations.Context;
using BuildingVitals.DataAccessImplementations.Repositories.Base;

namespace BuildingVitals.DataAccessImplementations.Repositories
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(AppDbContext context) 
            : base(context)
        {
        }
    }
}
