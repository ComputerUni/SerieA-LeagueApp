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
            CreateMap<MatchGoal, ResultMatchGoalDto>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src =>
                    src.Player != null ? $"{src.Player.FirstName} {src.Player.LastName}".Trim() : "Oyuncu Bilinmiyor"))
                .ForMember(dest => dest.AssistPlayerName, opt => opt.MapFrom(src =>
                    src.AssistPlayer != null ? $"{src.AssistPlayer.FirstName} {src.AssistPlayer.LastName}".Trim() : null));
        }
    }
}
