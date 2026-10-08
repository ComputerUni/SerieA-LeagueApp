using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerieA.API.Context;
using SerieA.API.DTOs.MatchCardDtos;
using SerieA.API.Entities;

namespace SerieA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchCardsController(ApiContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet("{matchId}")]
        public async Task<IActionResult> GetCardByMatchId(int matchId)
        {
            var card = await _context.MatchCards.Where(x => x.MatchId == matchId).Include(x => x.Team).ToListAsync();
            if(!card.Any())
            {
                return NotFound("Bu Maça Ait Kart Kaydı Bulunamadı");
            }
            var value = _mapper.Map<List<ResultMatchCardDto>>(card);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(CreateMatchCardDto createMatchCardDto)
        {
            var card = _mapper.Map<MatchCard>(createMatchCardDto);
            await _context.MatchCards.AddAsync(card);
            await _context.SaveChangesAsync();
            return Ok(new { id = card.Id, message = "Kart Kaydı Başarıyla Eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCard(UpdateMatchCardDto updateMatchCardDto)
        {
            var card = await _context.MatchCards.FindAsync(updateMatchCardDto.Id);
            if(card is null)
            {
                return NotFound("Güncellenmek İstenen Kart Kaydı Bulunamadı");
            }
            _mapper.Map(updateMatchCardDto, card);
            await _context.SaveChangesAsync();
            return Ok("Kart Kaydı Başarıyla Güncellendi");
        }
    }
}
