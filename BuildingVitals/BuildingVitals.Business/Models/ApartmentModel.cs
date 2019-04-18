using System;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models
{
    public class ApartmentModel : BaseModel
    {
        public string Floor { get; set; }

        public int Number { get; set; }

        public Guid OwnerId { get; set; }

        public Guid BuildingId { get; set; }
    }
}
