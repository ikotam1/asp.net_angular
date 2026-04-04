using Application.DTOs;
using Application.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = nameof(EUserRole.Admin))]
        public async Task<IActionResult> Get()
        {
            var users = await _service.GetUsers();
            return Ok(users);
        }
    }
}
