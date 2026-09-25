using SerieA.API.Entities.Common;
using SerieA.API.Entities.Enums;

namespace SerieA.API.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string LogoUrl { get; set; }
        public string City { get; set; }
        public Region Region { get; set; }
        public string Stadium { get; set; }
        public int StadiumCapacity { get; set; }
        public int FoundationYear { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public bool IsActive { get; set; } = true;

        public IList<Substitution> Substitutions { get; set; }
        public IList<MatchCard> MatchCards { get; set; }
        public IList<MatchGoal> MatchGoals { get; set; }
        public IList<Match> HomeMatches { get; set; }
        public IList<Match> AwayMatches { get; set; }

    }
}
