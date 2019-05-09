using System;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models
{
    public class MetricModel: BaseModel
    {
        public Guid SensorId { get; set; }

        public DateTime Date { get; set; }

        public double Humidity { get; set; }

        public double Temperature { get; set; }

    }
}
