using System;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models
{
    public class BuildingModel : BaseModel
    {
        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public string Address { get; set; }

    }
}
