using SerieA.API.Entities.Enums;

namespace SerieA.API.DTOs.TimelineEventDtos
{
    public class TimelineEventDto
    {
        public int Minute { get; set; }
        public int TeamId { get; set; }
        public bool IsHomeTeam { get; set; }
        public string EventType { get; set; }
        public CardType? CardType { get; set; }
        public string PrimaryText { get; set; }
        public string SecondaryText { get; set; }
        public string CurrentScore { get; set; }
    }
}
