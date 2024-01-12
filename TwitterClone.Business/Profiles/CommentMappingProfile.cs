using AutoMapper;
using TwitterClone.Business.Dtos.CommentDtos;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Profiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentDetailsDto>().ReverseMap();
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<Comment, CommentDetailedDto>();
        }
    }
}
