using System;
using System.Collections.Generic;
using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using BuildingVitals.BusinessImplementations.Services.Base;
using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;

namespace BuildingVitals.BusinessImplementations.Services
{
    public class BuildingService : BaseService<IBuildingRepository, Building, BuildingModel>, IBuildingService
    {
        public BuildingService(IBuildingRepository repository,
            IMapper serviceMapper) : base(repository, serviceMapper)
        {
        }

        public Guid AddBuilding(BuildingModel buildingModel)
        {
            return base.Add(buildingModel);
        }

        public List<BuildingModel> GetBuildingsByOwnerId(Guid ownerId)
        {
            var buildings = Repository.Filter(b => b.OwnerId == ownerId);
            return ServiceMapper.Map<List<BuildingModel>>(buildings);
        }
    }
}
