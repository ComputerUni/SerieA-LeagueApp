using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.StandingDtos;
using SerieA.API.DTOs.TeamDtos;

namespace SerieA.WebUI.Controllers
{
    public class StandingPanelController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/Standings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStandingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
