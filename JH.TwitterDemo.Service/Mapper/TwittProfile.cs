using AutoMapper;
using JH.TwitterDemo.Data.Entities;
using JH.TwitterDemo.Service.Models.Twitter;

namespace JH.TwitterDemo.Service.Mapper
{
    public class TwittProfile : Profile
    {
        public TwittProfile()
        {
            CreateMap<TwittInfo, Twitt>()
                .ForMember(dest => dest.TwitterId, opt => opt.MapFrom(src => src.Data.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Data.Text))
                .ForMember(dest => dest.HashTags, opt => opt.MapFrom(src => src.Data.Entities.HashTags))
                .ForMember(dest => dest.Mentions, opt => opt.MapFrom(src => src.Data.Entities.Mentions));

            CreateMap<Models.Twitter.HashTag, Data.Entities.HashTag>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End));

            CreateMap<Models.Twitter.Mention, Data.Entities.Mention>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.TwitterId, opt => opt.MapFrom(src => src.Id));
        }
    }
}