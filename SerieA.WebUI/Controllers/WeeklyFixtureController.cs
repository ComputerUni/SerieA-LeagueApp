using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.MatchCardDtos;
using SerieA.API.DTOs.MatchDtos;
using SerieA.API.Entities.Enums;
using SerieA.WebUI.Models;

namespace SerieA.WebUI.Controllers
{
    public class WeeklyFixtureController : Controller
    {
        public async Task<IActionResult> WeeklyFixtureList()
        {
            var client = new HttpClient();
            var matchResponse = await client.GetAsync("https://localhost:7078/api/Matches");
            if(matchResponse.IsSuccessStatusCode)
            {
                var matchJson = await matchResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMatchDto>>(matchJson);
                var viewModel = new FixturesViewModel
                {
                    TotalTeams = values.Select(m => m.HomeTeamId).Union(values.Select(m => m.AwayTeamId)).Count(),
                    TotalWeek = values.Max(x => x.Week),
                    CurrentWeek = values.Where(m => m.Status == MatchStatus.Completed).Select(m => m.Week).DefaultIfEmpty(1).Max()
                };
                return View(viewModel);
            }
            return View();
        }
    }
}
