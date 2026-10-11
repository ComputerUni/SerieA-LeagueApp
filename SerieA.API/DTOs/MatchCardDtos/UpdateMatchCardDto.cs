using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.MatchCardDtos
{
    public class UpdateMatchCardDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public int Minute { get; set; }
        public CardType CardType { get; set; }
    }
}
