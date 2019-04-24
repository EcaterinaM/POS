using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories.Base;

namespace BuildingVitals.DataAccessContracts.Repositories
{
    /// <summary>
    /// The apartment repository interface.
    /// </summary>
    /// <seealso>
    ///     <cref>BuildingVitals.DataAccessContracts.Repositories.Base.IBaseRepository{BuildingVitals.DataAccessContracts.Entities.ApartmentSensor}</cref>
    /// </seealso>
    public interface IMetricRepository: IBaseRepository<Metric>
    {
    }
}
