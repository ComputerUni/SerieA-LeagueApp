using SerieA.API.DTOs.MatchCardDtos;
using SerieA.API.DTOs.MatchDtos;
using SerieA.API.DTOs.MatchGoalDtos;
using SerieA.API.DTOs.SubstitutionDtos;
using SerieA.API.DTOs.TeamDtos;

namespace SerieA.WebUI.Models
{
    public class MatchListViewModel
    {
        public List<ResultMatchDto> Matches { get; set; }
        public List<ResultTeamDto> Teams { get; set; }
        public List<ResultMatchGoalDto> MatchGoals { get; set; }
        public List<ResultMatchCardDto> MatchCards { get; set; }
        public List<ResultSubstitutionDto> Substitutions { get; set; }
    }
}
