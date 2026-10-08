namespace SerieA.API.DTOs.MatchGoalDtos
{
    public class UpdateMatchGoalDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; }
        public string? AssistPlayerName { get; set; }
        public int Minute { get; set; }
    }
}
