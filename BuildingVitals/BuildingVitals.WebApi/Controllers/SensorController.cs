using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingVitals.WebApi.Controllers
{
    [Route("v1/sensors")]
    [ApiController]
    //[Authorize]

    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }


        [HttpPost("")]
        public IActionResult AddSensorToApartment(SensorModel sensorModel)
        {
            return Created("", _sensorService.AddSensorToApartment(sensorModel));
        }
    }
}
