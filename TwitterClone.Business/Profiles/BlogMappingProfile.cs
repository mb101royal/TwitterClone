using AutoMapper;
using TwitterClone.Business.Dtos.BlogDtos;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogCreateDto, Blog>();
            CreateMap<BlogUpdateDto, Blog>();
            CreateMap<Blog, BlogDetailedDto>();
            CreateMap<Blog, BlogDetailsDto>();
        }
    }
}
