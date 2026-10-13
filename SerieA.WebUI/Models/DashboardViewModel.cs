using SerieA.API.DTOs.DashboardDtos;
using SerieA.API.DTOs.StandingDtos;

namespace SerieA.WebUI.Models
{
    public class DashboardViewModel
    {
        public ResultDashboardDto KpiCards { get; set; }
        public List<ResultStandingDto> Standings { get; set; }
    }
}
