using System;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models
{
    public class SensorModel: BaseModel
    {
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}
