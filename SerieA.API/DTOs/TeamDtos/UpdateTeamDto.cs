using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.TeamDtos
{
    public class UpdateTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string LogoUrl { get; set; }
        public string City { get; set; }
        public Region Region { get; set; }
        public string Stadium { get; set; }
        public int StadiumCapacity { get; set; }
        public int FoundationYear { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public bool IsActive { get; set; }
    }
}
