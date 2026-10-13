using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController(ApiContext _context) : ControllerBase
    {
        [HttpGet("goal-top-scorers")]
        public async Task<IActionResult> GoalTopScorers()
        {
            var goals = await _context.MatchGoals.Include(x => x.Player).ThenInclude(p => p.Team).ToListAsync();
            var result = goals.GroupBy(g => g.Player)
                .Select(g => new
                {
                    PlayerId = g.Key.Id,
                    PlayerName = g.Key.FirstName + " " + g.Key.LastName,
                    TeamName = g.Key.Team.Name,
                    ImageUrl = g.Key.ImageUrl,
                    Goals = g.Count()
                }).OrderByDescending(x => x.Goals).Take(6).ToList();

            return Ok(result);
        }


        [HttpGet("assist-top-scorers")]
        public async Task<IActionResult> AssistTopScorers()
        {
            var assists = await _context.MatchGoals.Where(g => g.AssistPlayer != null).Include(g => g.AssistPlayer).ThenInclude(p => p.Team).ToListAsync();
            var result = assists.GroupBy(g => g.AssistPlayer).Select(g => new
            {
                AssistPlayerId = g.Key.Id,
                AssistPlayerName = g.Key.FirstName + " " + g.Key.LastName,
                TeamName = g.Key.Team.Name,
                ImageUrl = g.Key.ImageUrl,
                Assists = g.Count()
            }).OrderByDescending(x => x.Assists).Take(6).ToList();
            return Ok(result);
        }
    }
}
