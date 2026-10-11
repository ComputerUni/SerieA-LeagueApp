using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.MatchDtos;
using SerieA.API.DTOs.MatchStatisticsDtos;
using SerieA.API.DTOs.TeamDtos;
using SerieA.API.Entities.Enums;
using SerieA.WebUI.Models;
using System.Text;

namespace SerieA.WebUI.Controllers
{
    public class MatchController : Controller
    {
        public async Task<IActionResult> MatchList()
        {
            var client = new HttpClient();
            var matchResponse = await client.GetAsync("https://localhost:7078/api/Matches");
            var teamResponse = await client.GetAsync("https://localhost:7078/api/Teams");
            if (matchResponse.IsSuccessStatusCode && teamResponse.IsSuccessStatusCode)
            {
                var matchJson = await matchResponse.Content.ReadAsStringAsync();
                var teamJson = await teamResponse.Content.ReadAsStringAsync();
                var model = new MatchListViewModel
                {
                    Matches = JsonConvert.DeserializeObject<List<ResultMatchDto>>(matchJson),
                    Teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJson),
                };
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateMatch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDto createMatchDto)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(createMatchDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7078/api/Matches", stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("MatchList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteMatch(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync($"https://localhost:7078/api/Matches?id={id}");
            return RedirectToAction("MatchList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMatch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMatch(UpdateMatchDto updateMatchDto)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(updateMatchDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7078/api/Matches", stringContent);
            if(response.IsSuccessStatusCode)
            {
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false, message = "API güncelleme isteğini reddetti." });
        }

        public async Task<IActionResult> MatchDetail(int id)
        {
            var client = new HttpClient();

            var matchResponse = await client.GetAsync($"https://localhost:7078/api/Matches/{id}");
            if (!matchResponse.IsSuccessStatusCode) return NotFound();

            var match = JsonConvert.DeserializeObject<ResultMatchDto>(await matchResponse.Content.ReadAsStringAsync());

            var statistics = new ResultMatchStatisticsDto();
            var statsResponse = await client.GetAsync($"https://localhost:7078/api/MatchStatistics/{id}");
            if (statsResponse.IsSuccessStatusCode)
            {
                var statsList = JsonConvert.DeserializeObject<List<MatchStatisticItemDto>>(await statsResponse.Content.ReadAsStringAsync());

                var home = statsList?.FirstOrDefault(s => s.TeamId == match.HomeTeamId);
                var away = statsList?.FirstOrDefault(s => s.TeamId == match.AwayTeamId);

                if (home != null && away != null)
                {
                    statistics.PossessionHome = home.Possession;
                    statistics.PossessionAway = away.Possession;
                    statistics.ShotsHome = home.Shots;
                    statistics.ShotsAway = away.Shots;
                    statistics.ShotsOnTargetHome = home.ShotsOnTarget;
                    statistics.ShotsOnTargetAway = away.ShotsOnTarget;
                    statistics.PassesHome = home.Passes;
                    statistics.PassesAway = away.Passes;
                    statistics.PassAccuracyHome = home.PassAccuracy;
                    statistics.PassAccuracyAway = away.PassAccuracy;
                    statistics.CornersHome = home.Corners;
                    statistics.CornersAway = away.Corners;
                    statistics.FoulsHome = home.Fouls;
                    statistics.FoulsAway = away.Fouls;
                    statistics.OffsidesHome = home.Offsides;
                    statistics.OffsidesAway = away.Offsides;
                    statistics.YellowCardsHome = match.Cards.Count(c => c.TeamId == match.HomeTeamId && c.CardType == CardType.YellowCard);
                    statistics.YellowCardsAway = match.Cards.Count(c => c.TeamId == match.AwayTeamId && c.CardType == CardType.YellowCard);
                    statistics.RedCardsHome = match.Cards.Count(c => c.TeamId == match.HomeTeamId && c.CardType == CardType.RedCard);
                    statistics.RedCardsAway = match.Cards.Count(c => c.TeamId == match.AwayTeamId && c.CardType == CardType.RedCard);
                }
            }

            return View(new MatchStatisticsViewModel { Match = match, Statistics = statistics });
        }
    }
}
