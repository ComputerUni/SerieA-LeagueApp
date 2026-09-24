using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SerieA.API.Entities.Enums
{
    public enum CardType
    {
        [Display(Name = "Sarı Kart")]
        YellowCard = 1,

        [Display(Name = "Kırmızı Kart")]
        RedCard = 2,

        [Display(Name = "İkinci Sarıdan Kırmızı Kart")]
        SecondYellowCard = 3
    }
}
