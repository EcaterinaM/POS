using System;

namespace BuildingVitals.DataAccessContracts.Entities.Base
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
