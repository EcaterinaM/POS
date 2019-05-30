using System;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingVitals.WebApi.Controllers
{
    [Route("v1/buildings")]
    [ApiController]
    //[Authorize]

    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost("")]
        public IActionResult AddBuilding(BuildingModel buildingModel)
        {
           return Created("", _buildingService.AddBuilding(buildingModel));
        }

        [HttpGet("{ownerId}")]
        public IActionResult GetBuildingForOwner(Guid ownerId)
        {
            return Ok(_buildingService.GetBuildingsByOwnerId(ownerId));
        }

        [HttpGet("building/{id}")]
        public IActionResult GetBuildingById(Guid id)
        {
            return Ok(_buildingService.GetById(id));
        }
    }
}
