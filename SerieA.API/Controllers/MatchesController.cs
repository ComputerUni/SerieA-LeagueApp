using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.DTOs.MatchDtos;
using SerieA.API.Entities;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController(ApiContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> MatchList()
        {
            var matches = await _context.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam).ToListAsync();
            var values = _mapper.Map<List<ResultMatchDto>>(matches);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDto createMatchDto)
        {
            var match = _mapper.Map<Match>(createMatchDto);
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return Ok(new { id = match.Id, message = "Maç Kaydı Başarıyla Eklendi." });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var value = await _context.Matches.FindAsync(id);
            if (value == null)
            {
                return NotFound("Maç Kaydı Bulunamadı.");
            }

            _context.Matches.Remove(value);
            await _context.SaveChangesAsync();
            return Ok("Maç Kaydı Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatch(UpdateMatchDto updateMatchDto)
        {
            var match = await _context.Matches.FindAsync(updateMatchDto.Id);
            if (match is null)
            {
                return NotFound("Güncellenmek İstenen Maç Kaydı Bulunamadı.");
            }
            _mapper.Map(updateMatchDto, match);
            await _context.SaveChangesAsync();
            return Ok("Maç Kaydı Başarıyla Güncellendi");
        }

        [HttpGet("week/{week}")]
        public async Task<IActionResult> GetMatchesByWeek(int week)
        {
            var matches = await _context.Matches
                            .Include(x => x.HomeTeam)
                            .Include(x => x.AwayTeam)
                            .Where(x => x.Week == week).ToListAsync();
            if(!matches.Any())
            {
                return NotFound($"{week}. haftaya ait maç bulunamadı");
            }

            var values = _mapper.Map<List<ResultMatchDto>>(matches);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchDetailById(int id)
        {
            var detail = await _context.Matches.Include(x => x.AwayTeam).Include(x => x.HomeTeam).Include(x => x.Substitutions).Include(x => x.MatchCards).Include(x => x.MatchGoals).FirstOrDefaultAsync(x => x.Id == id);
            if(detail is null)
            {
                return NotFound($"{id} numaralı id'ye ait maç detayı bulunamadı");
            }
            var value = _mapper.Map<ResultMatchDto>(detail);
            return Ok(value);
        }
    }
}
