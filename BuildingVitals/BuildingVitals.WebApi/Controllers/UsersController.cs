using System.Threading.Tasks;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuildingVitals.WebApi.Controllers
{
    [Route("v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddAdmin(AddUserModel userModel)
        {
            await _userService.AddAdmin(userModel);
            return Ok();
        }

        [HttpPost("addTenant")]
        public async Task<IActionResult> AddTenant(AddUserWithApartmentModel userModel)
        {
            await _userService.AddTenant(userModel);
            return Ok();
        }
    }
}
