using SerieA.API.Entities;

namespace SerieA.API.DTOs.SubstitutionDtos
{
    public class ResultSubstitutionDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerIn { get; set; }
        public string PlayerOut { get; set; }
        public int Minute { get; set; }
    }
}
