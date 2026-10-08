using SerieA.API.DTOs.MatchCardDtos;
using SerieA.API.DTOs.MatchGoalDtos;
using SerieA.API.DTOs.MatchStatisticsDtos;
using SerieA.API.DTOs.SubstitutionDtos;
using SerieA.API.DTOs.TimelineEventDtos;
using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.MatchDetailDtos
{
    public class MatchDetailDto
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public DateTime MatchDate { get; set; }
        public string MatchTime { get; set; }
        public string FormattedDate { get; set; }
        public MatchStatus Status { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string Referee { get; set; }
        public string Attendance { get; set; }

        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamLogo { get; set; }
        public int? HomeScore { get; set; }

        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamLogo { get; set; }
        public int? AwayScore { get; set; }

        public List<ResultMatchGoalDto> Goals { get; set; } = new();
        public List<ResultMatchCardDto> Cards { get; set; } = new();
        public List<ResultSubstitutionDto> Substitutions { get; set; } = new();
        public List<TimelineEventDto> TimelineEvents { get; set; } = new();
        public MatchStatisticItemDto Stats { get; set; } = new();

    }
}
