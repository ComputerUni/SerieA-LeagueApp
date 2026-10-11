using SerieA.API.Entities;

namespace SerieA.API.DTOs.SubstitutionDtos
{
    public class ResultSubstitutionDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerInId { get; set; }
        public string? PlayerInName { get; set; }
        public int PlayerOutId { get; set; }
        public string? PlayerOutName { get; set; }
        public int Minute { get; set; }
    }
}
