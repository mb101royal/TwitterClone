using TwitterClone.Business.Dtos.TopicDtos;

namespace TwitterClone.Business.Services.Interfaces
{
    public interface ITopicService
    {
        public IEnumerable<TopicDetailsDto> GetAll();
        public Task<TopicDetailedDto> GetDetailedAsync(int id);
        public Task CreateAsync(TopicCreateDto dto);
        public Task Update(int id, TopicUpdateDto dto);
        public Task DeleteAsync(int id);
        public Task SoftDeleteAsync(int id);
        public Task SoftDeleteRevertAsync(int id);
    }
}
