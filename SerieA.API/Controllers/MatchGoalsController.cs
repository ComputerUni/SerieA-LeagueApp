using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.DTOs.MatchGoalDtos;
using SerieA.API.Entities;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchGoalsController(ApiContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet("{matchId}")]
        public async Task<IActionResult> GetGoalByMatchId(int matchId)
        {
            var goals = await _context.MatchGoals
                .AsNoTracking()
                .Where(x => x.MatchId == matchId)
                .Select(x => new ResultMatchGoalDto
                {
                    Id = x.Id,
                    MatchId = x.MatchId,
                    TeamId = x.TeamId,
                    Minute = x.Minute,
                    PlayerId = x.PlayerId,
                    AssistPlayerId = x.AssistPlayerId,
                    PlayerName = x.Player != null ? (x.Player.FirstName + " " + x.Player.LastName).Trim() : ("Oyuncu #" + x.PlayerId),
                    AssistPlayerName = x.AssistPlayer != null ? (x.AssistPlayer.FirstName + " " + x.AssistPlayer.LastName).Trim() : null
                })
                .ToListAsync();

            return Ok(goals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoal(CreateMatchGoalDto createMatchGoalDto)
        {
            var goal = _mapper.Map<MatchGoal>(createMatchGoalDto);
            await _context.MatchGoals.AddAsync(goal);
            await _context.SaveChangesAsync();
            return Ok(new { id = goal.Id, message = "Gol Kaydı Başarıyla Eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGoal(UpdateMatchGoalDto updateMatchGoalDto)
        {
            var goal = await _context.MatchGoals.FindAsync(updateMatchGoalDto.Id);
            if(goal is null)
            {
                return NotFound("Güncellenmek İstenen Takım Bulunamadı.");
            }
            _mapper.Map(updateMatchGoalDto, goal);
            await _context.SaveChangesAsync();
            return Ok("Gol Kaydı Başarıyla Güncellendi.");
        }
    }
}
