using SerieA.API.DTOs.MatchDtos;
using SerieA.API.DTOs.MatchStatisticsDtos;

namespace SerieA.WebUI.Models
{
    public class MatchStatisticsViewModel
    {
        public ResultMatchStatisticsDto Statistics { get; set; }
        public ResultMatchDto Match { get; set; }
    }
}
