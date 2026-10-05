using SerieA.API.DTOs.MatchDtos;
using SerieA.API.DTOs.TeamDtos;

namespace SerieA.WebUI.Models
{
    public class MatchListViewModel
    {
        public List<ResultMatchDto> Matches { get; set; }
        public List<ResultTeamDto> Teams { get; set; }
    }
}
