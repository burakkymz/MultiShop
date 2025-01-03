using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailFeatureComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var values = await _productService.GetProductByIdAsync(id);
            return View(values);

            //var client = _clientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7270/api/Products/" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
    }
}
