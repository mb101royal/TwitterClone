using TwitterClone.Business.Dtos.BlogDtos;

namespace TwitterClone.Business.Services.Interfaces
{
    public interface IBlogService
    {
        public IEnumerable<BlogDetailsDto> GetAll();
        public BlogDetailedDto GetDetailed(int id);
        public Task CreateAsync(BlogCreateDto dto);
        public Task Update(int id, BlogUpdateDto dto);
        public Task DeleteAsync(int id);
        public Task SoftDeleteAsync(int id);
        public Task SoftDeleteRevertAsync(int id);

    }
}
