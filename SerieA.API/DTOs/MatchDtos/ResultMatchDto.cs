using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.MatchDtos
{
    public class ResultMatchDto
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public string? HomeTeamLogo { get; set; }
        public int? HomeTeamScore { get; set; }
        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public string? AwayTeamLogo { get; set; }
        public int? AwayTeamScore { get; set; }
        public int Week { get; set; }
        public DateTime MatchDate { get; set; }
        public string? MatchTime => MatchDate.ToString("HH:mm");
        public MatchStatus Status { get; set; }
        public string? Stadium { get; set; }

    }
}
