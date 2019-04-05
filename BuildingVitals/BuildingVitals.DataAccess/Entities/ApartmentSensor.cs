using System;
using BuildingVitals.DataAccessContracts.Entities.Base;

namespace BuildingVitals.DataAccessContracts.Entities
{
    public class ApartmentSensor: BaseEntity
    {
        public Guid SensorId { get; set; }

        public Guid ApartmentId { get; set; }

        public Sensor Sensor { get; set; }

        public Apartment Apartment { get; set; }
    }
}
