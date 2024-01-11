using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwitterClone.Business.Dtos.TopicDtos;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.Core;
using TwitterClone.DatabaseAccessLayer.Contexts;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        ITopicService _service { get; }

        public TopicsController(ITopicService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetByIdAsync(id));
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("Create")]
        public async Task<IActionResult> Post(TopicCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
