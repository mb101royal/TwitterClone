using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TwitterClone.Business.Dtos.BlogDtos;
using TwitterClone.Business.Dtos.TopicDtos;
using TwitterClone.Business.Exceptions.Common;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Services.Implements
{
    public class BlogService : IBlogService
    {
        readonly string userId;

        IBlogRepository _blogRepo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        IMapper _mapper { get; }
        UserManager<AppUser> _userManager { get; }

        public BlogService(IBlogRepository blogRepo, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager, IMapper mapper)
        {
            _blogRepo = blogRepo;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            // Catch from Token service
            /* username = _contextAccessor.HttpContext?.User.Claims.First(x => x.Type == ClaimTypes.Name).Value ?? throw new NullReferenceException();*/
            userId = _contextAccessor.HttpContext?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value ?? throw new NullReferenceException();
            _mapper = mapper;
        }

        public async Task Create(BlogCreateDto dto)
        {
            var newBlog = _mapper.Map<Blog>(dto);

            await _blogRepo.CreateAsync(newBlog);

            await _blogRepo.SaveAsync();
        }

        public async Task Update(int id, BlogUpdateDto dto)
        {
            _checkId(id);

            _mapper.Map<Blog>(dto);

            await _blogRepo.SaveAsync();
        }

        public IEnumerable<BlogDetailsDto> GetAll()
        {
            var blogFromRepo = _blogRepo.GetAll().Where(t => t.IsDeleted == false);

            var mappedBlogFromRepo = _mapper.Map<IEnumerable<BlogDetailsDto>>(blogFromRepo);

            return mappedBlogFromRepo;
        }

        public async Task<BlogDetailedDto> GetDetailedAsync(int id)
        {
            _checkId(id);

            var blogFromRepo = await _blogRepo.Table.FindAsync(id) ?? throw new NotFoundException<Topic>();

            var mappedTopicDetailedDto = _mapper.Map<BlogDetailedDto>(blogFromRepo);

            return mappedTopicDetailedDto;
        }

        public async Task CreateAsync(BlogCreateDto dto)
        {
            var newBlog= _mapper.Map<Blog>(dto);

            await _blogRepo.CreateAsync(newBlog);

            await _blogRepo.SaveAsync();
        }

        public async Task UpdateAsync(int id, TopicUpdateDto dto)
        {
            _checkId(id);

            _mapper.Map<Topic>(dto);
        }

        public async Task DeleteAsync(int id)
        {
            _checkId(id);

            var blogFromRepo = await _blogRepo.Table.FindAsync(id) ?? throw new NotFoundException<Topic>();

            _blogRepo.Table.Remove(blogFromRepo);

            await _blogRepo.SaveAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            _checkId(id);

            var blogFromRepo = _blogRepo.Table.Find(id) ?? throw new NotFoundException<Blog>();

            blogFromRepo.IsDeleted = true;

            await _blogRepo.SaveAsync();
        }

        public async Task SoftDeleteRevertAsync(int id)
        {

        }


        void _checkId(int id)
        {
            if (id < 1) throw new Exception("Invalid id value.");
        }
    }
}
