using Microsoft.AspNetCore.Mvc;

namespace SerieA.WebUI.ViewComponents._AdminLayoutViewComponents
{
    public class _AdminLayoutSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
