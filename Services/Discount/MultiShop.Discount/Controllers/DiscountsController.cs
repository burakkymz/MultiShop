using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountServices _discountServices;

        public DiscountsController(IDiscountServices discountServices)
        {
            _discountServices = discountServices;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var result = await _discountServices.GetAllDiscountCouponAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var result = await _discountServices.GetByIdDiscountCouponAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountServices.CrateDiscountCouponAsync(createCouponDto);
            return Ok("Kupon Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountServices.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("Kupon Başarıyla Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountServices.DeleteDiscountCouponAsync(id);
            return Ok("Kupon Başarıyla Silindi");
        }
    }
}
