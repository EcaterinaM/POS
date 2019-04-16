using System;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuildingVitals.WebApi.Controllers
{
    [Route("v1/apartments")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpPost("")]
        public IActionResult AddApartment(ApartmentModel apartmentModel)
        {
            return Created("", _apartmentService.AddApartment(apartmentModel));
        }

        [HttpGet("{ownerId}")]
        public IActionResult GetApartmentByOwnerId(Guid ownerId)
        {
            return Ok(_apartmentService.GetApartmentByOwnerId(ownerId));
        }

        [HttpGet("{buildingId}/building")]
        public IActionResult GetApartmentsByBuildingId(Guid buildingId)
        {
            return Ok(_apartmentService.GetApartmentsByBuildingId(buildingId));
        }
    }
}
