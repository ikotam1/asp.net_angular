using Api.Common.Extensions;
using Application.DTOs.Request;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
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
            var result = await _service.Login(dto);

            if (result.IsSuccess)
            {
                Response.Cookies.Append("refresh_token", result.Value.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Path = "/api/auth/refresh-token",
#if DEBUG
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
#else
                    Secure = true,
                    SameSite = SameSiteMode.None,
#endif
                    Expires = DateTimeOffset.UtcNow.AddDays(10) // TODO: make it configurable
                });
            }

            return result.ToActionResult();
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshKey = Request.Cookies["refresh_token"] ?? string.Empty;
            var result = await _service.RefreshToken(refreshKey);

            return result.ToActionResult();
        }

        // TODO LOGOUT
    }
}
