using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services.Abstract
{
    public interface IDiscountServices
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CrateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
        Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code);
        int GetDiscountCouponCountRate(string code);
    }
}
