using SerieA.API.DTOs.StandingDtos;

namespace SerieA.WebUI.Models
{
    public class StandingsViewModel
    {
        public int CurrentWeek { get; set; }
        public int TotalTeams { get; set; }
        public List<ResultStandingDto> Standings { get; set; }
        public ResultStandingDto Leader { get; set; }
        public int LeadGap { get; set; }
        public ResultStandingDto BestAttack { get; set; }
        public double AvgGoalsFor { get; set; }
        public ResultStandingDto BestDefence { get; set; }
        public double AvgGoalsAgainst { get; set; }
        public ResultStandingDto RelegationStart { get; set; }
        public int GapToSafety { get; set; }
        public List<FormLeaderDto> FormLeaders { get; set; }
    }
}
