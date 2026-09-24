using SerieA.API.Entities.Common;

namespace SerieA.API.Entities
{
    public class Substitution : BaseEntity
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string PlayerIn { get; set; }
        public string PlayerOut { get; set; }
        public int Minute { get; set; }
    }
}
