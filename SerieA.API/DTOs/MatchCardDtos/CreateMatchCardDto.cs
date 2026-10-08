using SerieA.API.Entities;
using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.MatchCardDtos
{
    public class CreateMatchCardDto
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public CardType CardType { get; set; }
    }
}
