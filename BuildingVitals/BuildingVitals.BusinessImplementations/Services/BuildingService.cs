using System;
using System.Collections.Generic;
using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using BuildingVitals.BusinessContracts.Services.Base;
using BuildingVitals.BusinessImplementations.Services.Base;
using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;

namespace BuildingVitals.BusinessImplementations.Services
{
    public class BuildingService : BaseService<IBuildingRepository, Building, BuildingModel>, IBuildingService
    {
        protected BuildingService(IBuildingRepository repository, IMapper serviceMapper) : base(repository, serviceMapper)
        {
        }

        public Guid AddBuilding(BuildingModel buildingModel)
        {
            return Repository.Insert(ServiceMapper.Map<Building>(buildingModel)).Id;
        }

        public List<BuildingModel> GetByOwnerId(Guid ownerId)
        {
            return ServiceMapper.Map<List<BuildingModel>>(Repository.Filter(b => b.OwnerId == ownerId));
        }
    }
}
