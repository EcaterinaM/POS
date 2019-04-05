using System;
using BuildingVitals.DataAccessContracts.Entities.Base;

namespace BuildingVitals.DataAccessContracts.Entities
{
    public class Sensor: BaseEntity
    {
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}
