using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SerieA.API.DTOs.MatchDtos;
using SerieA.API.DTOs.StandingDtos;
using SerieA.API.Entities.Enums;
using SerieA.WebUI.Models;

namespace SerieA.WebUI.Controllers
{
    public class StandingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var standingsResponse = await client.GetAsync("https://localhost:7078/api/Standings");
            //var matchesResponse = await client.GetAsync("https://localhost:7078/api/Standings");
            var viewModel = new StandingsViewModel();

            if (standingsResponse.IsSuccessStatusCode)
            {
                var standingsJson = await standingsResponse.Content.ReadAsStringAsync();
                var standings = JsonConvert.DeserializeObject<List<ResultStandingDto>>(standingsJson);
                viewModel.Standings = standings;
                viewModel.TotalTeams = standings.Count;

                if (standings.Any())
                {
                    viewModel.CurrentWeek = standings.Max(x => x.PlayedMatch);

                    viewModel.Leader = standings.First();
                    var secondTeam = standings.Skip(1).FirstOrDefault();
                    viewModel.LeadGap = secondTeam != null ? (viewModel.Leader.Points - secondTeam.Points) : 0;

                    viewModel.BestAttack = standings.OrderByDescending(x => x.GoalsFor).First();
                    viewModel.AvgGoalsFor = viewModel.BestAttack.PlayedMatch > 0
                        ? (double)viewModel.BestAttack.GoalsFor / viewModel.BestAttack.PlayedMatch : 0;

                    viewModel.BestDefence = standings.OrderBy(x => x.GoalsAgainst).First();
                    viewModel.AvgGoalsAgainst = viewModel.BestDefence.PlayedMatch > 0
                        ? (double)viewModel.BestDefence.GoalsAgainst / viewModel.BestDefence.PlayedMatch : 0;

                    viewModel.RelegationStart = standings[19];
                    var safeTeam = standings[17];
                    viewModel.GapToSafety = safeTeam != null ? (safeTeam.Points - viewModel.RelegationStart.Points) : 0;

                    viewModel.FormLeaders = standings.Select(t => new
                    {
                        Team = t,
                        Points = t.LastFiveMatches != null
                            ? t.LastFiveMatches.Sum(m => m == "G" ? 3 : (m == "B" ? 1 : 0))
                            : 0

                    }).OrderByDescending(x => x.Points).ThenByDescending(x => x.Team.GoalDifference).Take(3)
                    .Select(x => new FormLeaderDto
                    {
                        TeamName = x.Team.TeamName,
                        LogoUrl = x.Team.LogoUrl,
                        FormPoints = x.Points,
                        Percentage = Math.Round(((double)x.Points / 15.0) * 100)
                    }).ToList();

                }

            }

            //if (matchesResponse.IsSuccessStatusCode)
            //{
            //    var matchesJson = await matchesResponse.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultMatchDto>>(matchesJson);

            //    viewModel.CurrentWeek = viewModel.Standings.Any() ? viewModel.Standings.Max(x => x.PlayedMatch) : 1;
            //}

            viewModel.TotalTeams = viewModel.Standings.Count;

            return View(viewModel);
        }
    }
}
