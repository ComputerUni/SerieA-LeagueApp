using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.DTOs.TeamDtos;
using SerieA.API.Entities;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController(ApiContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TeamList()
        {
            var teams = await _context.Teams.Where(x => x.IsActive).ToListAsync();
            var values = _mapper.Map<List<ResultTeamDto>>(teams);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            var team = _mapper.Map<Team>(createTeamDto);
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return Ok("Takım Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var value = await _context.Teams.FindAsync(id);
            if(value == null)
            {
                return NotFound("Takım Bilgisi Bulunamadı");
            }

            value.IsActive = false;
            await _context.SaveChangesAsync();
            return Ok("Takım Başarıyla Pasif Duruma Getirildi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var team = await _context.Teams.FindAsync(updateTeamDto.Id);
            if(team is null)
            {
                return NotFound("Güncellenmek İstenen Takım Bulunamadı.");
            }
            _mapper.Map(updateTeamDto, team);
            await _context.SaveChangesAsync();
            return Ok("Takım Başarıyla Güncellendi.");
        }
    }
}
