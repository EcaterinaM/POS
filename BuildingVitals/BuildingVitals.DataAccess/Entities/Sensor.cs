using System;
using System.Collections.Generic;
using BuildingVitals.DataAccessContracts.Entities.Base;

namespace BuildingVitals.DataAccessContracts.Entities
{
    public class Sensor: BaseEntity
    {
        public string Name { get; set; }

        public Guid ApartmentId { get; set; }

        public Apartment Apartment { get; set; }

        public List<Metric> Metrics { get; set; }   
    }
}
