using System;

namespace BuildingVitals.DataAccessContracts.Entities.Base
{
    /// <summary>
    /// IEntity interface.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }
    }
}
