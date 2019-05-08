using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.DataAccessContracts.Entities;

namespace BuildingVitals.BusinessImplementations.Configurations.AutoMapper
{
    public class MetricProfile: Profile
    {
        public MetricProfile()
        {
            CreateMap<Metric, MetricModel>();
            CreateMap<MetricModel, Metric>();
        }
    }
}
