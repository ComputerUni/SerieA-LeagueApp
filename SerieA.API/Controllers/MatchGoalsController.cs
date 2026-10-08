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
            var goal = await _context.MatchGoals.Where(x => x.MatchId == matchId).Include(x => x.Team).ToListAsync();
            if(!goal.Any())
            {
                return NotFound("Bu Maça Ait Gol Kaydı Bulunamadı.");
            }
            var value = _mapper.Map<List<ResultMatchGoalDto>>(goal);
            return Ok(value);
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
