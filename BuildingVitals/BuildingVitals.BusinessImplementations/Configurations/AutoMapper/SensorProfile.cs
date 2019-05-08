using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.DataAccessContracts.Entities;

namespace BuildingVitals.BusinessImplementations.Configurations.AutoMapper
{
    public class SensorProfile : Profile
    {
        public SensorProfile()
        {
            CreateMap<SensorModel, Sensor>();
            CreateMap<Sensor, SensorModel>();
        }
    }
}
