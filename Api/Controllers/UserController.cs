using Api.Common;
using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserLoginDto userLogin)
        {
            var result = await _userService.LogInUser(userLogin);
            return this.HandleResult(result);
        }
    }
}