using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.DataAccessContracts.Entities;

namespace BuildingVitals.BusinessImplementations.Configurations.AutoMapper
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<ApartmentModel, Apartment>();
            CreateMap<Apartment, ApartmentModel>();
        }
    }
}
