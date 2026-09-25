using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.MatchDtos
{
    public class UpdateMatchDto
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int Week { get; set; }
        public DateTime MatchDate { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public MatchStatus Status { get; set; }
        public string? Stadium { get; set; }
    }
}
