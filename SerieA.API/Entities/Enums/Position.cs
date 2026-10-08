using System.ComponentModel.DataAnnotations;

namespace SerieA.API.Entities.Enums
{
    public enum Position
    {
        [Display(Name = "Kaleci")]
        Goalkeeper = 1,

        [Display(Name = "Defans")]
        Defender = 2,

        [Display(Name = "Orta Saha")]
        Midfielder = 3,

        [Display(Name = "Forvet")]
        Forward = 4
    }
}
