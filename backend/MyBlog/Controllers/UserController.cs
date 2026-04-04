using Application.DTOs;
using Application.Services;
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
        public async Task<IActionResult> Get()
        {
            var users = await _service.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto dto)
        {
            await _service.CreateUser(dto);
            return Ok();
        }
    }
}
