using System;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingVitals.WebApi.Controllers
{
    [Route("v1/metrics")]
    [ApiController]
    //[Authorize]
    public class MetricsController : ControllerBase
    {
        private readonly IMetricService _metricService;

        public MetricsController(IMetricService metricService)
        {
            _metricService = metricService;
        }

        [HttpPost("")]
        public IActionResult AddMetric(MetricModel metricModel)
        {
            return Ok(_metricService.Add(metricModel));
        }

        [HttpGet("{propertyName}/{sensorId}")]
        public IActionResult GetMetricsByPropertyName(string propertyName, Guid sensorId)
        {
            return Ok(_metricService.GetSensorData(sensorId, propertyName));
        }
    }
}
