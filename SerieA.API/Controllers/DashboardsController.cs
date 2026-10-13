using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.DTOs.DashboardDtos;
using SerieA.API.Entities.Enums;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController(ApiContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetKpiCards()
        {
            var completedMatches = await _context.Matches.Where(m => m.Status == MatchStatus.Completed).ToListAsync();
            var teams = await _context.Teams.Where(x => x.IsActive).ToListAsync();

            var leaderTeam = teams.Select(team =>
            {
                var homeMatches = completedMatches.Where(m => m.HomeTeamId == team.Id).ToList();
                var awayMatches = completedMatches.Where(m => m.AwayTeamId == team.Id).ToList();
                var wins = homeMatches.Count(m => m.HomeScore > m.AwayScore) + awayMatches.Count(m => m.AwayScore > m.HomeScore);
                var draws = homeMatches.Count(m => m.HomeScore == m.AwayScore) + awayMatches.Count(m => m.AwayScore == m.HomeScore);
                var goalsFor = homeMatches.Sum(m => m.HomeScore ?? 0) + awayMatches.Sum(m => m.AwayScore ?? 0);
                var goalsAgainst = homeMatches.Sum(m => m.AwayScore ?? 0) + awayMatches.Sum(m => m.HomeScore ?? 0);
                var points = wins * 3 + draws;
                var average = goalsFor - goalsAgainst;

                return new
                {
                    TeamName = team.Name,
                    LogoUrl = team.LogoUrl,
                    Points = points,
                    Average = average,
                    GoalsFor = goalsFor
                };

            }).OrderByDescending(x => x.Points).ThenByDescending(x => x.Average).ThenByDescending(x => x.GoalsFor).FirstOrDefault();

            var totalMatches = await _context.Matches.CountAsync();
            var playedMatches = completedMatches.Count;
            var currentWeek = completedMatches.Any() ? completedMatches.Max(m => m.Week) : 0;

            var totalGoals = await _context.MatchGoals.CountAsync();
            var avgGoals = playedMatches > 0 ? Math.Round((double)totalGoals / playedMatches, 2) : 0;

            var topScorer = await _context.MatchGoals.GroupBy(g => new { g.PlayerId, g.Player.FirstName ,g.Player.LastName})
                .Select(g => new
                {
                    PlayerName = g.Key.FirstName + " " + g.Key.LastName,
                    Goals = g.Count()
                }).OrderByDescending(x => x.Goals).FirstOrDefaultAsync();

            var topAssistScorer = await _context.MatchGoals.Where(g => g.AssistPlayerId != null).GroupBy(g => new { g.AssistPlayerId, g.AssistPlayer.FirstName, g.AssistPlayer.LastName })
                .Select(g => new
                {
                    AssistPlayerName = g.Key.FirstName + " " + g.Key.LastName,
                    Assists = g.Count()
                }).OrderByDescending(x => x.Assists).FirstOrDefaultAsync();

            var result = new ResultDashboardDto
            {
                LeaderTeamName = leaderTeam.TeamName,
                LeaderTeamPoint = leaderTeam.Points,
                LeaderTeamAverage = leaderTeam.Average,
                LeaderTeamLogo = leaderTeam.LogoUrl,
                CurrentWeek = currentWeek,
                PlayedTotalMatch = playedMatches,
                TotalGoals = totalGoals,
                AvgGoalsPerMatch = avgGoals,
                LeaderGoalScorePlayerName = topScorer.PlayerName,
                LeaderGoalScore = topScorer.Goals,
                LeaderAssistScorePlayerName = topAssistScorer.AssistPlayerName,
                LeaderAssistScore = topAssistScorer.Assists
            };

            return Ok(result);
        }
    }
}
