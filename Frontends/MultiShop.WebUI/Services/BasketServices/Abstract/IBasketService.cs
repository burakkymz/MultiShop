using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices.Abstract
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItem(string productId);
    }
}
