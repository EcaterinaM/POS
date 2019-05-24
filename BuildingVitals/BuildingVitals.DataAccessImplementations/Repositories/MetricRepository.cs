using System;
using System.Collections.Generic;
using System.Linq;
using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Helpers;
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

        public IOrderedQueryable<Metric> GetLatestBySensorId(Guid sensorId, string property)
        {
            var oneDayBefore = DateTime.UtcNow.AddDays(-1);
            return Context.Set<Metric>()
                .Where(sd => sd.SensorId == sensorId && sd.Date >= oneDayBefore)
                .Where(MetricHelper.GetNotNullPropertyExpression(property))
                .OrderBy(sd => sd.Date);
        }
    }
}
