namespace SerieA.API.DTOs.SubstitutionDtos
{
    public class CreateSubstitutionDto
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerIn { get; set; }
        public string PlayerOut { get; set; }
        public int Minute { get; set; }
    }
}
