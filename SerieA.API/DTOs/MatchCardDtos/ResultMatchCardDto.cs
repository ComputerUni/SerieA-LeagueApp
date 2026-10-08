using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.MatchCardDtos
{
    public class ResultMatchCardDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public CardType CardType { get; set; }
    }
}
