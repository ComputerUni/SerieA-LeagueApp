using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.DTOs.SubstitutionDtos;
using SerieA.API.Entities;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubstitutionsController(ApiContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet("{matchId}")]
        public async Task<IActionResult> GetSubstitutionByMatchId(int matchId)
        {
            var substitution = await _context.Substitutions.Where(x => x.MatchId == matchId).Include(x => x.Team).ToListAsync();
            if (!substitution.Any())
            {
                return NotFound("Bu Maça Ait Oyuncu Değişikliği Bulunamadı");
            }
            var value = _mapper.Map<List<ResultSubstitutionDto>>(substitution);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubstitution(CreateSubstitutionDto createSubstitutionDto)
        {
            var substitution = _mapper.Map<Substitution>(createSubstitutionDto);
            await _context.Substitutions.AddAsync(substitution);
            await _context.SaveChangesAsync();
            return Ok(new { id = substitution.Id, message = "Değişiklik Kaydı Başarıyla Eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubstitution(UpdateSubstitutionDto updateSubstitutionDto)
        {
            var substitution = await _context.Substitutions.FindAsync(updateSubstitutionDto.Id);
            if(substitution is null)
            {
                return NotFound("Güncellenmek İstenen Değişiklik Kaydı Bulunamadı");
            }
            _mapper.Map(updateSubstitutionDto, substitution);
            await _context.SaveChangesAsync();
            return Ok("Değişiklik Kaydı Başarıyla Güncellendi");
        }
    }
}
