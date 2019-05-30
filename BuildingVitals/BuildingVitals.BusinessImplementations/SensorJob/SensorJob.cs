using System;
using System.Globalization;
using System.Linq;
using BuildingVitals.BusinessContracts.SensorJob;
using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;

namespace BuildingVitals.BusinessImplementations.SensorJob
{
    public class SensorJob : ISensorJob
    {
        private readonly IMetricRepository metricRepository;

        private readonly ISensorRepository sensorRepository;

        public SensorJob(IMetricRepository metricRepository,
            ISensorRepository sensorRepository)
        {
            this.metricRepository = metricRepository;
            this.sensorRepository = sensorRepository;
        }

        public void AddSensorData()
        {
            var sensors = sensorRepository.GetAll().ToList();

            var random = new Random();
            var humidityRange = 60;
            var temperatureRange = 40;

            foreach (var s in sensors)
            {
                var metric = new Metric
                {
                    Date = DateTime.Now,
                    Humidity = (random.NextDouble() * humidityRange).ToString(CultureInfo.InvariantCulture),
                    Temperature = (random.NextDouble() * temperatureRange).ToString(CultureInfo.InvariantCulture),
                    SensorId = s.Id,
                    Id = Guid.NewGuid()
                };

                metricRepository.Insert(metric);
                metricRepository.Save();
            }
        }
    }
}
