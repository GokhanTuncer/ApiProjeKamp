using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _NavbarAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          return View();
        }
    }
}
