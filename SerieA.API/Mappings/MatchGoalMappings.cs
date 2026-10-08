using AutoMapper;
using SerieA.API.DTOs.MatchGoalDtos;
using SerieA.API.Entities;

namespace SerieA.API.Mappings
{
    public class MatchGoalMappings : Profile
    {
        public MatchGoalMappings()
        {
            CreateMap<CreateMatchGoalDto, MatchGoal>();
            CreateMap<UpdateMatchGoalDto, MatchGoal>();
            CreateMap<MatchGoal, ResultMatchGoalDto>();
        }
    }
}
