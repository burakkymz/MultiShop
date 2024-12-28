using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductImageController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("ProductImageDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Ürünler";
            ViewBag.v2 = "Ürün Görsel İşlemleri";
            ViewBag.v3 = "Kategori Listesi";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync(
                "https://localhost:7270/api/ProductImages/GetByProductIdProductImage?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }

            var emptyDto = new UpdateProductImageDto { ProductID = id };
            return View(emptyDto);
        }

        [Route("ProductImageDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto, string id)
        {
            updateProductImageDto.ProductID = id;

            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7270/api/ProductImages/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
