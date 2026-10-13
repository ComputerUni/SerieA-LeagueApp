using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.DashboardDtos;
using SerieA.API.DTOs.StandingDtos;
using SerieA.WebUI.Models;

namespace SerieA.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var viewModel = new DashboardViewModel();
            var kpiResponse = await client.GetAsync("https://localhost:7078/api/Dashboards");
            if(kpiResponse.IsSuccessStatusCode)
            {
                var kpiData = await kpiResponse.Content.ReadAsStringAsync();
                viewModel.KpiCards = JsonConvert.DeserializeObject<ResultDashboardDto>(kpiData);      
            }

            var standingsResponse = await client.GetAsync("https://localhost:7078/api/Standings");
            if (standingsResponse.IsSuccessStatusCode)
            {
                var standingsData = await standingsResponse.Content.ReadAsStringAsync();
                viewModel.Standings = JsonConvert.DeserializeObject<List<ResultStandingDto>>(standingsData);
            }

            return View(viewModel);
        }
    }
}
