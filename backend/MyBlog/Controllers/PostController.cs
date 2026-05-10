using System.Security.Claims;
using Api.Common.Extensions;
using Application.DTOs.Request;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var posts = await _service.GetAllPosts(Guid.Parse(userId));
            return posts.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            request.AuthorId = Guid.Parse(userId);
            var result = await _service.CreatePost(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
