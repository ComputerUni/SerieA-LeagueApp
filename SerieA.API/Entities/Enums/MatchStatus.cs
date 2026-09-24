using System.ComponentModel.DataAnnotations;

namespace SerieA.API.Entities.Enums
{
    public enum MatchStatus
    {
        [Display(Name = "Oynanmadı")]
        Upcoming = 1,

        [Display(Name = "Oynandı")]
        Completed = 2,

        [Display(Name = "Canlı")]
        Live = 3,

        [Display(Name = "Ertelendi")]
        Postponed = 4
    }
}
