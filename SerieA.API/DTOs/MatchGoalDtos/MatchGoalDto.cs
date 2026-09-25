namespace SerieA.API.DTOs.MatchGoalDtos
{
    public class MatchGoalDto
    {
        public int TeamId { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public string AssistPlayer { get; set; }
    }
}
