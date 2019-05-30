using System;
using System.Linq;
using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using BuildingVitals.BusinessImplementations.Services.Base;
using BuildingVitals.Common.Helpers;
using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Helpers;
using BuildingVitals.DataAccessContracts.Repositories;

namespace BuildingVitals.BusinessImplementations.Services
{
    public class MetricService: BaseService<IMetricRepository, Metric, MetricModel>, IMetricService
    {
        public MetricService(IMetricRepository repository, IMapper serviceMapper) : base(repository, serviceMapper)
        {
        }

        public void AddMetric(MetricModel metricModel)
        {
            base.Add(metricModel);
        }

        public SensorDataListModel GetSensorData(Guid sensorId, string property)
        {
            var sensorMetrics = Repository.GetLatestBySensorId(sensorId, property);

            return new SensorDataListModel()
            {
                SensorId = sensorId,
                DataList = sensorMetrics
                    .Select(MetricHelper.GetPropertyExpression(property))
                    .ToList()
                    .ConvertAll( NumberExtensions.ParseDoubleValue),
                Dates = sensorMetrics.Select(sm => sm.Date).ToList()
            };
        }

        public PropertyMinMax GetMaxAndMinValues(string property, Guid sensorId)
        {
            var metrics = Repository.GetAll().Where(s => s.Id == sensorId);


            return new PropertyMinMax()
            {
                MaxValue = "30",
                MaxValueDate = DateTime.Now.AddDays(-40).GetDateTimeFormats()[0],
                MinValue = "20.6",
                MinValueDate = DateTime.Now.AddDays(-2).GetDateTimeFormats()[0]
            };
        }
    }
}   
