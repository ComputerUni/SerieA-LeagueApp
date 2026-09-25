using Microsoft.AspNetCore.Mvc;

namespace SerieA.WebUI.ViewComponents._AdminLayoutViewComponents
{
    public class _AdminLayoutTopbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
