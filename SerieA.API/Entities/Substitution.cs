using SerieA.API.Entities.Common;

namespace SerieA.API.Entities
{
    public class Substitution : BaseEntity
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int PlayerInId { get; set; }
        public Player? PlayerIn { get; set; }
        public int PlayerOutId { get; set; }
        public Player? PlayerOut { get; set; }
        public int Minute { get; set; }
    }
}
