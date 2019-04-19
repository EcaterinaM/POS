using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.DataAccessContracts.Entities;

namespace BuildingVitals.BusinessImplementations.Configurations.AutoMapper
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<BuildingModel, Building>();
            CreateMap<Building, BuildingModel>();
        }
    }
}
