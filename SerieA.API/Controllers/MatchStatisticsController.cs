using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.DTOs.MatchStatisticsDtos;
using SerieA.API.Entities;
using SerieA.API.Entities.Enums;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatisticsController(ApiContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMatchStatistics(CreateMatchStatisticsDto createMatchStatisticsDto)
        {
            var match = await _context.Matches.FindAsync(createMatchStatisticsDto.MatchId);
            if(match is null)
            {
                return NotFound("Maç Bulunamadı");
            }
            if(match.Status != MatchStatus.Completed && match.Status != MatchStatus.Live)
            {
                return BadRequest("İstatistik yalnızca oynanan veya canlı maçlara girilebilir");
            }
            var exists = await _context.MatchStatistics.AnyAsync(x => x.MatchId == createMatchStatisticsDto.MatchId && x.TeamId == createMatchStatisticsDto.TeamId);
            if(exists)
            {
                return BadRequest("Bu takımın istatistiği zaten girilmiş");
            }
            var matchStatistic = _mapper.Map<MatchStatistic>(createMatchStatisticsDto);
            await _context.MatchStatistics.AddAsync(matchStatistic);
            await _context.SaveChangesAsync();
            return Ok(new { id = matchStatistic.Id, message = "Maç İstatistik Kaydı Başarıyla Eklendi." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatchStatistic(int id, UpdateMatchStatisticsDto updateMatchStatisticsDto)
        {
            var matchStatistic = await _context.MatchStatistics.FindAsync(id);
            if(matchStatistic is null)
            {
                return NotFound("Güncellenmek İstenen Maç İstatistik Kaydı Bulunamadı.");
            }
            _mapper.Map(updateMatchStatisticsDto, matchStatistic);
            await _context.SaveChangesAsync();
            return Ok("Maç İstatistik Kaydı Başarıyla Güncellendi");
        }

        [HttpGet("{matchId}")]
        public async Task<IActionResult> GetMatchStatisticByMatchId(int matchId)
        {
            var matchStatistic = await _context.MatchStatistics.Where(x => x.MatchId == matchId).Include(x => x.Team).ToListAsync();
            if(!matchStatistic.Any())
            {
                return NotFound("Bu maça ait istatistik bulunamadı");
            }
            var value = _mapper.Map<List<MatchStatisticItemDto>>(matchStatistic);
            return Ok(value);
        }
    }
}
