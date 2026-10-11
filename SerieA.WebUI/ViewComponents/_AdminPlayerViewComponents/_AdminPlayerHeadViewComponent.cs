using Microsoft.AspNetCore.Mvc;

namespace SerieA.WebUI.ViewComponents._AdminPlayerViewComponents
{
    public class _AdminPlayerHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
