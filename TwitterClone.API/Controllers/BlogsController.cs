using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Dtos.BlogDtos;
using TwitterClone.Business.Services.Interfaces;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogService _blogService { get; }

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> Get(BlogDetailsDto dto)
        {
            var blogs = _blogService.GetAll();

            return Ok(blogs);
        }

        [Authorize]
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var specificBlog = _blogService.GetDetailed(id);

            return Ok(specificBlog);
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Post(BlogCreateDto dto)
        {
            await _blogService.CreateAsync(dto);

            return Ok();
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteAsync(id);

            return Ok();
        }
    }
}
