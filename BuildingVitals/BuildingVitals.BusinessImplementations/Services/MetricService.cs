using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using BuildingVitals.BusinessImplementations.Services.Base;
using BuildingVitals.DataAccessContracts.Entities;
using BuildingVitals.DataAccessContracts.Repositories;

namespace BuildingVitals.BusinessImplementations.Services
{
    public class MetricService: BaseService<IMetricRepository, Metric, MetricModel>, IMetricService
    {
        public MetricService(IMetricRepository repository, IMapper serviceMapper) : base(repository, serviceMapper)
        {
        }


        public void AddMetric(MetricModel metricModel)
        {
            base.Add(metricModel);
        }
    }
}   
