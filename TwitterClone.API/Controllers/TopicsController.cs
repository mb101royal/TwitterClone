using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwitterClone.Business.Dtos.TopicDtos;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.DatabaseAccessLayer.Contexts;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TopicsController : ControllerBase
    {
        ITopicService _service { get; }

        public TopicsController(ITopicService service)
        {
            _service = service;
        }

        [HttpGet("AllTopics")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("TopicById/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetByIdAsync(id));
        }

        [HttpPost("CreateTopic")]
        public async Task<IActionResult> Post(TopicCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
