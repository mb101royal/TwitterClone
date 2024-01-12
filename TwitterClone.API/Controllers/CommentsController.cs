using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Services.Interfaces;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService { get; }

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("All")]
        public IActionResult Get()
        {
            var comments = _commentService.GetAll();

            return Ok(comments);
        }

    }
}
