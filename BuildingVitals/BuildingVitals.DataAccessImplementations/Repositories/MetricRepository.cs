using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;
using BuildingVitals.DataAccessImplementations.Context;
using BuildingVitals.DataAccessImplementations.Repositories.Base;

namespace BuildingVitals.DataAccessImplementations.Repositories
{
    public class MetricRepository: BaseRepository<Metric>, IMetricRepository
    {
        public MetricRepository(AppDbContext context) : base(context)
        {
        }
    }
}
