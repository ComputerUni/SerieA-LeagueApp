using SerieA.API.Entities.Common;
using SerieA.API.Entities.Enums;

namespace SerieA.API.Entities
{
    public class MatchCard : BaseEntity
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public CardType CardType { get; set; }
    }
}
