using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.StandingDtos;

namespace SerieA.WebUI.Controllers
{
    public class StatController : Controller
    {
        public async Task<IActionResult> TopGoals()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7078/api/Stats/goal-top-scorers");
            var data = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TopScorerDto>>(data);
            return View(values);
        }


        public async Task<IActionResult> TopAssists()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7078/api/Stats/assist-top-scorers");
            var data = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TopAssistDto>>(data);
            return View(values);
        }

    }
}
