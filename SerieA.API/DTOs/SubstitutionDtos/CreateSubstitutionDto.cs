namespace SerieA.API.DTOs.SubstitutionDtos
{
    public class CreateSubstitutionDto
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerInId { get; set; }
        public int PlayerOutId { get; set; }
        public int Minute { get; set; }
    }
}
