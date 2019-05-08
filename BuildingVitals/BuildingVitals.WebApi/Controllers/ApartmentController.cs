using System;
using System.Net;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingVitals.WebApi.Controllers
{
    [Route("v1/apartments")]
    [ApiController]
    [Authorize]
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

        [HttpGet("")]
        public IActionResult GetApartments()
        {
            return Ok(_apartmentService.GetAllApartments());
        }

        [HttpGet("{id}")]
        public IActionResult GetApartmentById(Guid id)
        {
            return Ok(_apartmentService.GetApartmentById(id));
        }

        [HttpGet("{ownerId}/owner")]
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
