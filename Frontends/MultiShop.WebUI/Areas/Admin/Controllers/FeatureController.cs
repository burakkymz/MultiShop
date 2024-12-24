using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public FeatureController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Öne Çıkan Alanlar";
            ViewBag.v2 = "Öne Çıkan Alan Listesi";
            ViewBag.v3 = "Ana Sayfa Öne Çıkan Alan İşlemleri";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7270/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Öne Çıkan Alanlar";
            ViewBag.v2 = "Öne Çıkan Alan Listesi";
            ViewBag.v3 = "Ana Sayfa Öne Çıkan Alan İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7270/api/Features", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7270/api/Features?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Öne Çıkan Alanlar";
            ViewBag.v2 = "Öne Çıkan Alan Listesi";
            ViewBag.v3 = "Ana Sayfa Öne Çıkan Alan İşlemleri";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7270/api/Features/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7270/api/Features/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
