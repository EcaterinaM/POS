using System;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services.Base;

namespace BuildingVitals.BusinessContracts.Services
{
    public interface IMetricService: IBaseService<MetricModel>
    {
        /// <summary>
        /// Adds the specified apartment sensor model.
        /// </summary>
        /// <param name="metricModel">The apartment sensor model.</param>
        void AddMetric(MetricModel metricModel);

        SensorDataListModel GetSensorData(Guid sensorId, string property);

        PropertyMinMax GetMaxAndMinValues(string property, Guid sensorId);
    }
}
    