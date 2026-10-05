using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Web.Models;
using System.Text.Json;

namespace RapidApi.Web.Controllers
{
    public class WeatherController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(string cityName)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://open-weather13.p.rapidapi.com/city?lang=TR&city={cityName}"),
                Headers =
            {
                { "x-rapidapi-key", "deneme" },
                { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
            },

            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                return View(result);
            }
        }
    }
}
