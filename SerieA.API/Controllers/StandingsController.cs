using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.Entities.Enums;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingsController(ApiContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStandings()
        {
            var completed = await _context.Matches.Where(x => x.Status == MatchStatus.Completed).ToListAsync();
            var teams = await _context.Teams.ToListAsync();

            var standings = teams.Select(team =>
            {
                var homeMatches = completed.Where(m => m.HomeTeamId == team.Id).ToList();
                var awayMatches = completed.Where(m => m.AwayTeamId == team.Id).ToList();

                var wins = homeMatches.Count(m => m.HomeScore > m.AwayScore) + awayMatches.Count(m => m.AwayScore > m.HomeScore);

                var draws = homeMatches.Count(m => m.HomeScore == m.AwayScore) + awayMatches.Count(m => m.AwayScore == m.HomeScore);

                var loses = homeMatches.Count(m => m.HomeScore < m.AwayScore) + awayMatches.Count(m => m.AwayScore < m.HomeScore);

                var goalsFor = homeMatches.Sum(m => m.HomeScore ?? 0) + awayMatches.Sum(m => m.AwayScore ?? 0);

                var goalsAgainst = homeMatches.Sum(m => m.AwayScore ?? 0) + awayMatches.Sum(m => m.HomeScore ?? 0);

                var points = wins * 3 + draws;

                return new 
                           
            })
        }
    }
}
