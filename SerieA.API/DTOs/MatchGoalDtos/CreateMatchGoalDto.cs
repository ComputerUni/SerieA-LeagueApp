namespace SerieA.API.DTOs.MatchGoalDtos
{
    public class CreateMatchGoalDto
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public int? AssistPlayerId { get; set; }
        public int Minute { get; set; }
    }
}
