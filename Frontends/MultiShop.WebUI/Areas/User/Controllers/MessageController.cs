using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        public IActionResult Inbox()
        {
            return View();
        }

        public IActionResult SendBox()
        {
            return View();
        }
    }
}
