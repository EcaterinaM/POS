using System;
using System.Collections.Generic;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services.Base;

namespace BuildingVitals.BusinessContracts.Services
{
    /// <summary>
    /// The building service interface.
    /// </summary>
    public interface IBuildingService: IBaseService<BuildingModel>
    {
        /// <summary>
        /// Adds the builing.
        /// </summary>
        /// <param name="buildingModel">The building model.</param>
        /// <returns></returns>
        Guid AddBuilding(BuildingModel buildingModel);

        /// <summary>
        /// Gets the by owner identifier.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <returns></returns>
        List<BuildingModel> GetBuildingsByOwnerId(Guid ownerId);
    }
}
