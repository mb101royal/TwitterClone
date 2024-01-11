using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using TwitterClone.Business.Dtos.BlogDtos;
using TwitterClone.Business.Dtos.TopicDtos;
using TwitterClone.Business.Exceptions.Common;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Services.Implements
{
    public class TopicService : ITopicService
    {
        ITopicRepository _topicRepo { get; }
        IMapper _mapper { get; }

        public TopicService(ITopicRepository repo, IMapper mapper)
        {
            _topicRepo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(TopicCreateDto dto)
        {


            var newTopic = _mapper.Map<Topic>(dto);

            await _topicRepo.CreateAsync(newTopic);

            await _topicRepo.SaveAsync();
        }

        public async Task Update(int id, TopicUpdateDto dto)
        {
            _checkId(id);

            _mapper.Map<Topic>(dto);
        }

        public async Task DeleteAsync(int id)
        {
            _checkId(id);

            var topicFromRepo = await _topicRepo.Table.FindAsync(id) ?? throw new NotFoundException<Topic>();

            _topicRepo.Table.Remove(topicFromRepo);

            await _topicRepo.SaveAsync();
        }

        public IEnumerable<TopicDetailsDto> GetAll()
        {
            var topicFromRepo = _topicRepo.GetAll().Where(t => t.IsDeleted == false);

            var mappedTopicFromRepo = _mapper.Map<IEnumerable<TopicDetailsDto>>(topicFromRepo);

            return mappedTopicFromRepo;
        }

        public async Task<TopicDetailedDto> GetDetailedAsync(int id)
        {
            _checkId(id);

            var topicFromRepo = await _topicRepo.Table.FindAsync(id) ?? throw new NotFoundException<Topic>();

            var mappedTopicDetailedDto = _mapper.Map<TopicDetailedDto>(topicFromRepo);

            // Another variant
            // TopicDetailedDto topicDetailedDto = new() {assigning props...}

            // var mappedTopicDetailedDto = _mapper.Map(topicFromRepo, topicDetailedDto);

            return mappedTopicDetailedDto;
        }

        public Task SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteRevertAsync(int id)
        {
            throw new NotImplementedException();
        }

        void _checkId(int id)
        {
            if (id < 1) throw new Exception("Invalid id value.");
        }
    }
}
