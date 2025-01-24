using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices.Abstract;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, 
            IUserStatisticService userStatisticService, ICommentService commentService, 
            IMessageStatisticService messageStatisticService, IDiscountStatisticService discountStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _messageStatisticService = messageStatisticService;
            _discountStatisticService = discountStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v = "İstatistikler";
            ViewBag.v1 = "İstatistikler";
            ViewBag.v2 = "İstatistik İşlemleri";
            ViewBag.v3 = "İstatistik Listesi";

            var geBrandCount = await _catalogStatisticService.GetBrandCount();
            var getProductCount = await _catalogStatisticService.GetProductCount();
            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            var getAvgPrice = await _catalogStatisticService.GetProductAvgPrice();

            var getUserCount = await _userStatisticService.GetUsercount();

            var getCommentCount = await _commentService.GetTotalCommentCount();
            var getActiveCommentCount = await _commentService.GetActiveCommentCount();
            var getPassiveCommentCount = await _commentService.GetPassiveCommentCount();

            var getMessageCount = await _messageStatisticService.GetTotalMessageCount();

            var getDiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();

            ViewBag.getBrandCount = geBrandCount;
            ViewBag.getProductCount = getProductCount;
            ViewBag.getCategoryCount = getCategoryCount;
            ViewBag.getMaxPriceProductName = getMaxPriceProductName;
            ViewBag.getMinPriceProductName = getMinPriceProductName;
            ViewBag.getAvgPrice = getAvgPrice;

            ViewBag.getCommentCount = getCommentCount;
            ViewBag.getActiveCommentCount = getActiveCommentCount;
            ViewBag.getPassiveCommentCount = getPassiveCommentCount;

            ViewBag.getMessageCount = getMessageCount;

            ViewBag.getUserCount = getUserCount;

            ViewBag.getDiscountCouponCount = getDiscountCouponCount;
            return View();
        }
    }
}
