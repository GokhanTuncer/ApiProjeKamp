using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult CategoryList()
        {
            return View();
        }
    }
}
