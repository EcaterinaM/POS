using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.DataAccessContracts.Entities;

namespace BuildingVitals.BusinessImplementations.Configurations.AutoMapper
{
    public class ApartmentSensorProfile : Profile
    {
        public ApartmentSensorProfile()
        {
            CreateMap<ApartmentSensor, MetricModel>();
            CreateMap<MetricModel, ApartmentSensor>();
        }
    }
}
