using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.TopicDtos;
using TwitterClone.Business.Exceptions.Topic;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Services.Implements
{
    public class TopicService : ITopicService
    {
        readonly ITopicRepository _repo;

        public TopicService(ITopicRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAsync(TopicCreateDto dto)
        {
            await _repo.CreateAsync(new Topic
            {
                Name = dto.Name
            });
            await _repo.SaveAsync();
        }

        public IQueryable<TopicDetailsDto> GetAll()
            => _repo.GetAll().Select(table => new TopicDetailsDto
            {
                Id = table.Id,
                Name = table.Name
            });

        public Task<TopicDetailDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /*public async Task<TopicDetailDto> GetByIdAsync(int id)
        {
            var result = await _repo.Table.AnyAsync(i => i.Id == id);

            if (!result) throw new TopicNotFoundException();

            var topicFromRepo = _repo.Table.Select(t =>
            {
                
            });

            return (new TopicDetailDto
            {
                Id = topicFromRepo.Id, CreateDate = topicFromRepo.CreateDate,

            });
        }*/
    }
}
