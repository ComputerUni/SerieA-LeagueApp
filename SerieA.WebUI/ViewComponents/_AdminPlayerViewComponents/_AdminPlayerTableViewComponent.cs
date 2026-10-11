using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SerieA.API.DTOs.PlayerDtos;
using SerieA.API.DTOs.TeamDtos;
using SerieA.API.Entities;
using SerieA.API.Entities.Enums;
using SerieA.API.Extensions;

namespace SerieA.WebUI.ViewComponents._AdminPlayerViewComponents
{
    public class _AdminPlayerTableViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();

            var teamResponse = await client.GetAsync("https://localhost:7078/api/Teams");
            if(teamResponse.IsSuccessStatusCode)
            {
                var teamJson = await teamResponse.Content.ReadAsStringAsync();
                var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJson);
                ViewBag.Teams = teams;
            }

            ViewBag.Positions = Enum.GetValues(typeof(Position))
               .Cast<Position>()
               .Select(x => new SelectListItem
               {
                   Text = x.GetDisplayName(),
                   Value = ((int)x).ToString()
               }).ToList();


            var playerResponse = await client.GetAsync("https://localhost:7078/api/Players");
            if (playerResponse.IsSuccessStatusCode)
            {
                var playerJson = await playerResponse.Content.ReadAsStringAsync();
                var players = JsonConvert.DeserializeObject<List<ResultPlayerDto>>(playerJson);
                return View(players);
            }

            return View();
        }
    }
}
