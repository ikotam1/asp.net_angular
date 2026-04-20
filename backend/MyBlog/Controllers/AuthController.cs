using Application.DTOs.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest dto)
        {
            var result = await _service.Register(dto);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest dto)
        {
            var token = await _service.Login(dto);
            
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }

        // TODO LOGOUT
    }
}
