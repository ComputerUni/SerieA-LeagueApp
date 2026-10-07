using SerieA.API.Entities.Common;

namespace SerieA.API.Entities
{
    public class MatchStatistic : BaseEntity
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int Possession { get; set; }
        public int Shots { get; set; }
        public int ShotsOnTarget { get; set; }
        public int Passes { get; set; }
        public int PassAccuracy { get; set; }
        public int Corners { get; set; }
        public int Fouls { get; set; }
        public int Offsides { get; set; }


    }
}
