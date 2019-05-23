using System;
using System.Collections.Generic;
using System.Linq;
using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;
using BuildingVitals.DataAccessImplementations.Context;
using BuildingVitals.DataAccessImplementations.Repositories.Base;

namespace BuildingVitals.DataAccessImplementations.Repositories
{
    public class MetricRepository : BaseRepository<Metric>, IMetricRepository
    {
        public MetricRepository(AppDbContext context) : base(context)
        {
        }

        public List<Metric> GetTemperatureMetricsForSensor(Guid id)
        {
            //var x = Context.Set<Metric>().Where(m => m.SensorId == id)
            //     .GroupBy(m => m.Temperature);
            return Context.Set<Metric>().Where(m => m.SensorId == id).ToList();
        }
    }
}
