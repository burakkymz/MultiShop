using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.MessageServices.Abstract;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }
        public async Task<IActionResult> Inbox()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Mesajlarım";
            ViewBag.directory3 = "Gelen Mesajlar";
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessageAsync(user.Id);
            return View(values);
        }

        public async Task<IActionResult> SendBox()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Mesajlarım";
            ViewBag.directory3 = "Giden Mesajlar";
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetSendboxMessageAsync(user.Id);
            return View(values);
        }
    }
}
