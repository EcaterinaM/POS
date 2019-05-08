using System;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services.Base;

namespace BuildingVitals.BusinessContracts.Services
{
    public interface ISensorService: IBaseService<SensorModel>
    {
        Guid AddSensor(SensorModel sensorModel);
    }
}
