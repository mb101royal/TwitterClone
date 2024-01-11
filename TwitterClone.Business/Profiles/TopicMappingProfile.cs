using AutoMapper;
using TwitterClone.Business.Dtos.TopicDtos;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Profiles
{
    public class TopicMappingProfile : Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<TopicCreateDto, Topic>();
            CreateMap<TopicUpdateDto, Topic>();
            CreateMap<Topic, TopicDetailedDto>();
            CreateMap<Topic, TopicDetailsDto>();
        }
    }
}
