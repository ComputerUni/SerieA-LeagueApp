namespace SerieA.API.DTOs.MatchGoalDtos
{
    public class CreateMatchGoalDto
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; }
        public string? AssistPlayerName { get; set; }
        public int Minute { get; set; }
    }
}
