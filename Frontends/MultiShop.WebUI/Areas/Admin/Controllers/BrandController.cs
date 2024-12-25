using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BrandController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Markalar";
            ViewBag.v2 = "Marka Listesi";
            ViewBag.v3 = "Marka İşlemleri";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7270/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Markalar";
            ViewBag.v2 = "Marka Listesi";
            ViewBag.v3 = "Marka İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7270/api/Brands", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7270/api/Brands?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Markalar";
            ViewBag.v2 = "Marka Listesi";
            ViewBag.v3 = "Marka İşlemleri";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7270/api/Brands/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7270/api/Brands/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }
    }
}
