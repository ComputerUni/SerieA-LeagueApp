namespace SerieA.API.DTOs.DashboardDtos
{
    public class ResultDashboardDto
    {
        public string LeaderTeamName { get; set; }
        public int LeaderTeamPoint { get; set; }
        public int LeaderTeamAverage { get; set; }
        public string LeaderTeamLogo { get; set; }
        public int CurrentWeek { get; set; }
        public int PlayedTotalMatch { get; set; }
        public int SeasonTotalMatch { get; set; }
        public int TotalGoals { get; set; }
        public double AvgGoalsPerMatch { get; set; }
        public int LeaderGoalScore { get; set; }
        public string LeaderGoalScorePlayerName { get; set; }
        public int LeaderAssistScore { get; set; }
        public string LeaderAssistScorePlayerName { get; set; }

    }
}
