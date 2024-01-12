using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwitterClone.Business.Dtos.TopicDtos;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Implements;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.Core;
using TwitterClone.DatabaseAccessLayer.Contexts;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        ITopicService _topicService { get; }

        public TopicsController(ITopicService service)
        {
            _topicService = service;
        }

        [HttpGet("All")]
        public IActionResult Get()
        {
            var topics = _topicService.GetAll();

            return Ok(topics);
        }

        [Authorize]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var specificTopic = await _topicService.GetDetailedAsync(id);

            return Ok(specificTopic);
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Post(TopicCreateDto dto)
        {
            await _topicService.CreateAsync(dto);

            return Ok();
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _topicService.DeleteAsync(id);

            return Ok();
        }
    }
}
