using SerieA.API.Entities;
using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.MatchDtos
{
    public class CreateMatchDto
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int Week { get; set; }
        public DateTime MatchDate { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Upcoming;
        public string? Stadium { get; set; }
    }
}
