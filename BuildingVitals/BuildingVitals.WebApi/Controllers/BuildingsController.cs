using System;
using System.Net;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuildingVitals.WebApi.Controllers
{
    [Route("v1/buildings")]
    [ApiController]
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
           return Ok(_buildingService.AddBuilding(buildingModel));
        }

        [HttpGet("{ownerId}")]
        public IActionResult AddBuilding(Guid ownerId)
        {
            return Ok(_buildingService.GetByOwnerId(ownerId));
        }
    }
}
