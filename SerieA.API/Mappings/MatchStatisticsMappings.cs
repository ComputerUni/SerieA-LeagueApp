using AutoMapper;
using SerieA.API.DTOs.MatchStatisticsDtos;
using SerieA.API.Entities;

namespace SerieA.API.Mappings
{
    public class MatchStatisticsMappings : Profile
    {
        public MatchStatisticsMappings()
        {
            CreateMap<MatchStatistic, ResultMatchStatisticsDto>();
            CreateMap<CreateMatchStatisticsDto, MatchStatistic>().ReverseMap();
            CreateMap<Match, UpdateMatchStatisticsDto>().ReverseMap();
        }
    }
}
