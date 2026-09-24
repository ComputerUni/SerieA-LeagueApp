using SerieA.API.Entities.Common;
using SerieA.API.Entities.Enums;

namespace SerieA.API.Entities
{
    public class Match : BaseEntity
    {
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int Week { get; set; }
        public DateTime MatchDate { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public MatchStatus Status { get; set; }
        public string Stadium { get; set; }


        public IList<Substitution> Substitutions { get; set; }
        public IList<MatchCard> MatchCards { get; set; }
        public IList<MatchGoal> MatchGoals { get; set; }

    }
}
