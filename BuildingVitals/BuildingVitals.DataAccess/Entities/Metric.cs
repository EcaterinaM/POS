using System;
using BuildingVitals.DataAccessContracts.Entities.Base;

namespace BuildingVitals.DataAccessContracts.Entities
{
    public class Metric : BaseEntity
    {
        public Guid SensorId  { get; set; }

        public DateTime Date { get; set; }

        public string Temperature { get; set; }
        
        public string Humidty { get; set; }

        public Sensor Sensor { get; set; }  
    }
}
