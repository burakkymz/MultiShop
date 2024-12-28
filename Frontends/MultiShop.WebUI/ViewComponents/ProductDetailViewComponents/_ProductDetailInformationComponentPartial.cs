using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _ProductDetailInformationComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync(
                "https://localhost:7270/api/ProductDetails/GetByProductIdProductDetail?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
