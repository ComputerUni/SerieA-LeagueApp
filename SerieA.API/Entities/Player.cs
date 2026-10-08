using SerieA.API.Entities.Common;
using SerieA.API.Entities.Enums;

namespace SerieA.API.Entities
{
    public class Player : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ShirtNumber { get; set; }
        public Position Position { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Nationality { get; set; }
        public string? ImageUrl { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public IList<MatchGoal> ScoredGoals { get; set; }
        public IList<MatchGoal> AssistedGoals { get; set; }
        public IList<MatchCard> MatchCards { get; set; }
        public IList<Substitution> SubstitutedIn { get; set; }
        public IList<Substitution> SubstitutedOut { get; set; }

    }
}
