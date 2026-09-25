using System.ComponentModel.DataAnnotations;

namespace SerieA.API.Entities.Enums
{
    public enum Region
    {
        [Display(Name = "Kuzey İtalya")]
        North = 1,

        [Display(Name = "Orta İtalya")]
        Central = 2,

        [Display(Name = "Güney İtalya")]
        South = 3,

        [Display(Name = "Adalar")]
        Islands = 4,

    }
}
