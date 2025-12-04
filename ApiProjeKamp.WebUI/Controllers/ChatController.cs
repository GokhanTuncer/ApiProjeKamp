using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult SendChatWithAI()
        {
            return View();
        }
    }
}
