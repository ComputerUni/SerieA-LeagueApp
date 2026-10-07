using AutoMapper;
using SerieA.API.DTOs.MatchCardDtos;
using SerieA.API.DTOs.MatchDtos;
using SerieA.API.DTOs.MatchGoalDtos;
using SerieA.API.DTOs.SubstitutionDtos;
using SerieA.API.Entities;

namespace SerieA.API.Mappings
{
    public class MatchMappings : Profile
    {
        public MatchMappings()
        {
            CreateMap<Match, ResultMatchDto>()
                .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.Name))
                .ForMember(dest => dest.HomeTeamLogo, opt => opt.MapFrom(src => src.HomeTeam.LogoUrl))
                .ForMember(dest => dest.HomeTeamScore, opt => opt.MapFrom(src => src.HomeScore))
                .ForMember(dest => dest.AwayTeamScore, opt => opt.MapFrom(src => src.AwayScore))
                .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.Name))
                .ForMember(dest => dest.AwayTeamLogo, opt => opt.MapFrom(src => src.AwayTeam.LogoUrl))
                .ForMember(dest => dest.Goals, opt => opt.MapFrom(src => src.MatchGoals))
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.MatchCards))
                .ForMember(dest => dest.Substitutions, opt => opt.MapFrom(src => src.Substitutions));
            CreateMap<CreateMatchDto, Match>().ReverseMap();
            CreateMap<Match, UpdateMatchDto>().ReverseMap();
            CreateMap<MatchGoal, MatchGoalDto>();
            CreateMap<MatchCard, MatchCardDto>();
            CreateMap<Substitution, SubstitutionDto>();
        }
    }
}
