using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.PlayerDtos;
using SerieA.API.DTOs.TeamDtos;

namespace SerieA.WebUI.ViewComponents._AdminPlayerViewComponents
{
    public class _AdminPlayerLeagueStripViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();

            var playerResponse = await client.GetAsync("https://localhost:7078/api/Players");
            int playerCount = 0;
            if(playerResponse.IsSuccessStatusCode)
            {
                var playerJson = await playerResponse.Content.ReadAsStringAsync();
                var players = JsonConvert.DeserializeObject<List<ResultPlayerDto>>(playerJson);
                playerCount = players?.Count ?? 0;
            }

            var teamResponse = await client.GetAsync("https://localhost:7078/api/Teams");
            int teamCount = 0;
            if (teamResponse.IsSuccessStatusCode)
            {
                var teamJson = await teamResponse.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJson);
                teamCount = teams?.Count ?? 0;
            }

            ViewBag.PlayerCount = teamCount;
            ViewBag.TeamCount = teamCount;

            return View();
        }
    }
}
