using AutoMapper;
using SerieA.API.DTOs.PlayerDtos;
using SerieA.API.Entities;

namespace SerieA.API.Mappings
{
    public class PlayerMappings : Profile
    {
        public PlayerMappings()
        {
            CreateMap<Player, ResultPlayerDto>().ReverseMap();
            CreateMap<UpdatePlayerDto, Player>();
            CreateMap<CreatePlayerDto, Player>();
        }
    }
}
