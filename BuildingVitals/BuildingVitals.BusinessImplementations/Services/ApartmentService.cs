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
    public class ApartmentService : BaseService<IApartmentRepository, Apartment, ApartmentModel>, IApartmentService
    {
        public ApartmentService(IApartmentRepository repository, IMapper serviceMapper)
            : base(repository, serviceMapper)
        {}

        public Guid AddApartment(ApartmentModel apartmentModel)
        {
            return base.Add(apartmentModel);
        }

        public ApartmentModel GetApartmentByOwnerId(Guid ownerId)
        {
            var apartment = Repository.GetById(ownerId);
            return ServiceMapper.Map<ApartmentModel>(apartment);
        }

        public List<ApartmentModel> GetApartmentsByBuildingId(Guid buildingId)
        {
            var apartments = Repository.Filter(b => b.BuildingId == buildingId);
            return ServiceMapper.Map<List<ApartmentModel>>(apartments);
        }
    }
}
