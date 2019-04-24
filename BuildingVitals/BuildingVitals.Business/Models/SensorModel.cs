using System;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models
{
    public class SensorModel: BaseModel
    {
        public string Name { get; set; }

        public Guid ApartmentId { get; set; }
    }
}
