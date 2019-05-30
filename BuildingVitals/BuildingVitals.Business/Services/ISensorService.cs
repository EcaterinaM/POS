using System;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services.Base;

namespace BuildingVitals.BusinessContracts.Services
{
    public interface ISensorService: IBaseService<SensorModel>
    {
        Guid AddSensorToApartment(SensorModel sensorModel);

        SensorModel GetByApartmentId(Guid id);
    }
}
