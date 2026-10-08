using SerieA.API.Entities.Common;

namespace SerieA.API.Entities
{
    public class MatchGoal : BaseEntity
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
        public int? AssistPlayerId { get; set; }
        public Player? AssistPlayer { get; set; }
        public int Minute { get; set; }
    }
}
