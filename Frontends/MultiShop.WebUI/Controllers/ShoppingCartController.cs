using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices.Abstract;
using MultiShop.WebUI.Services.CatalogServices.ProductServices.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                ProductImageUrl = values.ImageUrl,
                Quantity = 1
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
