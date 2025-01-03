using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IHttpClientFactory _clientFactory;

        public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService, IHttpClientFactory clientFactory)
        {
            _productDetailService = productDetailService;
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
            //var client = _clientFactory.CreateClient();
            //var responseMessage = await client.GetAsync(
            //    "https://localhost:7270/api/ProductDetails/GetByProductIdProductDetail?id=" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<GetByIdProductDetailDto>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
    }
}
