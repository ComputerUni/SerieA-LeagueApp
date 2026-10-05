using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SerieA.API.Entities.Enums;
using SerieA.API.Extensions;

namespace SerieA.WebUI.ViewComponents._AdminTeamViewComponents
{
    public class _AdminTeamTableViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Regions = Enum.GetValues(typeof(Region))
                .Cast<Region>()
                .Select(x => new SelectListItem
                {
                    Text = x.GetDisplayName(),
                    Value = ((int)x).ToString()
                }).ToList();


            return View();


        }
    }
}
