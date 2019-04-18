using System;
using System.Collections.Generic;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services.Base;

namespace BuildingVitals.BusinessContracts.Services
{
    public interface IApartmentService: IBaseService<ApartmentModel>
    {
        Guid AddApartment(ApartmentModel apartmentModel);

        ApartmentModel GetApartmentByOwnerId(Guid ownerId);

        List<ApartmentModel> GetApartmentsByBuildingId(Guid buildingId);
    }
}
