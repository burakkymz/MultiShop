using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services.Abstract
{
    public interface IDiscountServices
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CrateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    }
}
