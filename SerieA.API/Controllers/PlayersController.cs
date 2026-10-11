using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.DTOs.MatchDtos;
using SerieA.API.DTOs.PlayerDtos;
using SerieA.API.Entities;
using System.Text.RegularExpressions;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController(ApiContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> PlayerList()
        {
            var players = await _context.Players.ToListAsync();
            var values = _mapper.Map<List<ResultPlayerDto>>(players);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPlayerId(int id)
        {
            var player = await _context.Players.FindAsync(id);
            return Ok(player);
        }

        [HttpGet("ByTeam/{teamId}")]
        public async Task<IActionResult> GetByTeam(int teamId)
        {
            var players = await _context.Players.Where(x => x.TeamId == teamId).ToListAsync();
            var values = _mapper.Map<List<ResultPlayerDto>>(players);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerDto createPlayerDto)
        {
            var player = _mapper.Map<Player>(createPlayerDto);
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return Ok(new { id = player.Id, message = "Oyuncu başarıyla eklendi" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var value = await _context.Players.FindAsync(id);
            if (value == null)
            {
                return NotFound("Oyuncu Bilgisi Bulunamadı");
            }
            _context.Players.Remove(value);
            await _context.SaveChangesAsync();
            return Ok("Oyuncu Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(UpdatePlayerDto updatePlayerDto)
        {
            var player = await _context.Players.FindAsync(updatePlayerDto.Id);
            if (player is null)
            {
                return NotFound("Güncellenmek İstenen Oyuncu Kaydı Bulunamadı.");
            }
            _mapper.Map(updatePlayerDto, player);
            await _context.SaveChangesAsync();
            return Ok("Oyuncu Kaydı Başarıyla Güncellendi");

        }

    }
}
