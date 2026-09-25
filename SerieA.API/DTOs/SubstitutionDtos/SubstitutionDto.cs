namespace SerieA.API.DTOs.SubstitutionDtos
{
    public class SubstitutionDto
    {
        public int TeamId { get; set; }
        public string PlayerIn { get; set; }
        public string PlayerOut { get; set; }
        public int Minute { get; set; }
    }
}
