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

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get(BlogDetailsDto dto)
        {
            return Ok();
        }

        /*[HttpPost("Create")]
        public async Task<IActionResult> Post(BlogCreateDto dto)
        {
            await _blogService.Create(dto);

            return Ok();
        }*/
    }
}
