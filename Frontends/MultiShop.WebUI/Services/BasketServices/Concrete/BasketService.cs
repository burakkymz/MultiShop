using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.BasketServices.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {

            var values = await GetBasket();

            if (values == null)
            {
                values = new BasketTotalDto();
                values.BasketItems = new List<BasketItemDto>();
            }

            if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
            {
                values.BasketItems.Add(basketItemDto);
            }
            else
            {
                var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
                existingItem.Quantity += basketItemDto.Quantity;
            }

            await SaveBasket(values);


            //var values = await GetBasket();
            //if (values != null)
            //{
            //    if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
            //    {
            //        values.BasketItems.Add(basketItemDto);
            //    }
            //    else
            //    {
            //        values = new BasketTotalDto();
            //        values.BasketItems.Add(basketItemDto);
            //    }
            //}
            //await SaveBasket(values);
        }


        public async Task<BasketTotalDto> GetBasket()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
            //var responseMessage = await _httpClient.GetAsync("baskets");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<BasketTotalDto>(jsonData);
            //return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}
