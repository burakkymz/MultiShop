using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/Brand")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
