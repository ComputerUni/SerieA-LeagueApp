using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.MatchDtos;
using SerieA.API.DTOs.TeamDtos;
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
    }
}
