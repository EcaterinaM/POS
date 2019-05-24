using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Metric> GetTemperatureMetricsForSensor(Guid id);

        IOrderedQueryable<Metric> GetLatestBySensorId(Guid sensorId, string property);
    }
}
