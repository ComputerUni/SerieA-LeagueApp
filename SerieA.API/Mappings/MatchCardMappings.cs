using AutoMapper;
using SerieA.API.DTOs.MatchCardDtos;
using SerieA.API.Entities;

namespace SerieA.API.Mappings
{
    public class MatchCardMappings : Profile
    {
        public MatchCardMappings()
        {
            CreateMap<CreateMatchCardDto, MatchCard>();
            CreateMap<UpdateMatchCardDto, MatchCard>();
            CreateMap<MatchCard, ResultMatchCardDto>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src =>
                    src.Player != null ? $"{src.Player.FirstName} {src.Player.LastName}".Trim() : "Oyuncu Bilinmiyor"));
        }
    }
}
