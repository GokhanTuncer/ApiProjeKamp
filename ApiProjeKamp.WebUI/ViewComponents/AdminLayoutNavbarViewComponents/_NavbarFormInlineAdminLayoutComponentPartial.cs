using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarFormInlineAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
