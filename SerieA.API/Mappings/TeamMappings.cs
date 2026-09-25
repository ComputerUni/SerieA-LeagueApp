using AutoMapper;
using SerieA.API.DTOs.TeamDtos;
using SerieA.API.Entities;

namespace SerieA.API.Mappings
{
    public class TeamMappings : Profile
    {
        public TeamMappings()
        {
            CreateMap<Team, ResultTeamDto>().ReverseMap();
            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();            
        }
    }
}
