namespace SerieA.API.DTOs.MatchStatisticsDtos
{
    public class UpdateMatchStatisticsDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
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
