using SerieA.API.Entities.Common;

namespace SerieA.API.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }

        public IList<Substitution> Substitutions { get; set; }
        public IList<MatchCard> MatchCards { get; set; }
        public IList<MatchGoal> MatchGoals { get; set; }
        public IList<Match> HomeMatches { get; set; }
        public IList<Match> AwayMatches { get; set; }

    }
}
