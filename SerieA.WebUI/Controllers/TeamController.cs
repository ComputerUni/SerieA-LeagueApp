using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.TeamDtos;
using System.Text;

namespace SerieA.WebUI.Controllers
{
    public class TeamController : Controller
    {
        public async Task<IActionResult> TeamList()
        {
            var client = new HttpClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/Teams");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(createTeamDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7078/api/Teams", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }

            return View();
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync($"https://localhost:7078/api/Teams?=id" + id);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(updateTeamDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7078/api/Teams", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }

    }
}
