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
            var matches = await _context.Matches.ToListAsync();
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
            if(value == null)
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
            if(match is null)
            {
                return NotFound("Güncellenmek İstenen Maç Kaydı Bulunamadı.");
            }
            _mapper.Map(updateMatchDto, match);
            await _context.SaveChangesAsync();
            return Ok("Maç Kaydı Başarıyla Güncellendi");
        }
    }
}
