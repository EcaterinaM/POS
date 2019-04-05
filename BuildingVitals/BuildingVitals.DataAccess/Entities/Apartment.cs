using System;
using BuildingVitals.DataAccessContracts.Entities.Base;

namespace BuildingVitals.DataAccessContracts.Entities
{
    public class Apartment : BaseEntity
    {
        public string Floor { get; set; }

        public int Number { get; set; }

        public Guid OwnerId { get; set; }

        public Guid BuildingId { get; set; }

        public Building Building { get; set; }
    }
}
