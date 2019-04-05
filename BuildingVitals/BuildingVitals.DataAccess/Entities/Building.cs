using System;
using System.Collections.Generic;
using BuildingVitals.DataAccessContracts.Entities.Base;

namespace BuildingVitals.DataAccessContracts.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public string Address { get; set; }

        public List<Apartment> Apartments { get; set; }
    }
}
