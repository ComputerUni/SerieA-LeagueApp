using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.PlayerDtos
{
    public class ResultPlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ShirtNumber { get; set; }
        public Position Position { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Nationality { get; set; }
        public string? ImageUrl { get; set; }
        public int TeamId { get; set; }
    }
}
