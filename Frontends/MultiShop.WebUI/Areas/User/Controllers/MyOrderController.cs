using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.OrderServices.OrderOderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOderingService _orderingService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderOderingService orderOderingService, IUserService userService)
        {
            _orderingService = orderOderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var userInfo = await _userService.GetUserInfo();
            var values = await _orderingService.GetOrderingByUserId(userInfo.Id);
            return View(values);
        }
    }
}
