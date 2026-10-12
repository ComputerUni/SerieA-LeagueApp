using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SerieA.API.DTOs.PlayerDtos;
using SerieA.API.DTOs.TeamDtos;
using SerieA.API.Entities.Enums;
using SerieA.API.Extensions;
using System.Text;

namespace SerieA.WebUI.Controllers
{
    public class PlayerController : Controller
    {
        private async Task GetPosition()
        {
            ViewBag.Positions = Enum.GetValues(typeof(Position))
                .Cast<Position>()
                .Select(x => new SelectListItem
                {
                    Text = x.GetDisplayName(),
                    Value = ((int)x).ToString()
                }).ToList();
        }



        private async Task<List<ResultTeamDto>> GetTeams()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7078/api/Teams");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
            return values;
        }

        public async Task<IActionResult> PlayerList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreatePlayer()
        {
            await GetPosition();
            var teams = await GetTeams();
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerDto createPlayerDto)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(createPlayerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7078/api/Players", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("PlayerList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePlayer(int id)
        {
            await GetPosition();
            var teams = await GetTeams();
            ViewBag.Teams = teams;
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7078/api/Players/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdatePlayerDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePlayer(UpdatePlayerDto updatePlayerDto)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(updatePlayerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7078/api/Players", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("PlayerList");
            }
            return View();
        }


    }
}
