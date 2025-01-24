using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices.Abstract;
using MultiShop.WebUI.Services.UserIdentityServices.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerService;
        public UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
        {
            _userIdentityService = userIdentityService;
            _cargoCustomerService = cargoCustomerService;
        }
        public async Task<IActionResult> UserList()
        {
            ViewBag.v = "Kullanıcılar";
            ViewBag.v1 = "Kullanıcılar";
            ViewBag.v2 = "Kullanıcı İşlemleri";
            ViewBag.v3 = "Kullanıcı Listesi";

            var values = await _userIdentityService.GetAllUserListAsync();
            return View(values);
        }


        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var values = await _cargoCustomerService.GetByIdCargoCustomerInfoAsync(id);
            return View(values);
        }
    }
}
