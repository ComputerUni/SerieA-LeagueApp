using AutoMapper;
using SerieA.API.DTOs.MatchStatisticsDtos;
using SerieA.API.Entities;

namespace SerieA.API.Mappings
{
    public class MatchStatisticsMappings : Profile
    {
        public MatchStatisticsMappings()
        {
            CreateMap<MatchStatistic, MatchStatisticItemDto>()
                .ForMember(dest => dest.Possession, opt => opt.MapFrom(src => src.Possession))
                .ForMember(dest => dest.Shots, opt => opt.MapFrom(src => src.Shots))
                .ForMember(dest => dest.ShotsOnTarget, opt => opt.MapFrom(src => src.ShotsOnTarget))
                .ForMember(dest => dest.Passes, opt => opt.MapFrom(src => src.Passes))
                .ForMember(dest => dest.PassAccuracy, opt => opt.MapFrom(src => src.PassAccuracy))
                .ForMember(dest => dest.Corners, opt => opt.MapFrom(src => src.Corners))
                .ForMember(dest => dest.Fouls, opt => opt.MapFrom(src => src.Fouls))
                .ForMember(dest => dest.Offsides, opt => opt.MapFrom(src => src.Offsides)).ReverseMap();
            CreateMap<CreateMatchStatisticsDto, MatchStatistic>().ReverseMap();
            CreateMap<Match, UpdateMatchStatisticsDto>().ReverseMap();
        }
    }
}
