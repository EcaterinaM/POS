using System;
using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using BuildingVitals.BusinessImplementations.Services.Base;
using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;

namespace BuildingVitals.BusinessImplementations.Services
{
    public class SensorService: BaseService<ISensorRepository, Sensor, SensorModel>, ISensorService
    {
        public SensorService(ISensorRepository repository, IMapper serviceMapper)
            : base(repository, serviceMapper)
        { }

        public Guid AddSensor(SensorModel sensorModel)
        {
            return base.Add(sensorModel);
        }
    }
}
