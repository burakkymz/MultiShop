using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AboutController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Hakımızda";
            ViewBag.v2 = "Hakımızda Listesi";
            ViewBag.v3 = "Hakımızda İşlemleri";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7270/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Hakımızda";
            ViewBag.v2 = "Hakımızda Listesi";
            ViewBag.v3 = "Hakımızda İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createAboutDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7270/api/Abouts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7270/api/Abouts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.v = "Ana Sayfa";
            ViewBag.v1 = "Hakımızda";
            ViewBag.v2 = "Hakımızda Listesi";
            ViewBag.v3 = "Hakımızda İşlemleri";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7270/api/Abouts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateAboutDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7270/api/Abouts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
}
