﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketServices _basketServices;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketServices basketServices, ILoginService loginService)
        {
            _basketServices = basketServices;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;
            var values = await _basketServices.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketServices.SaveBasket(basketTotalDto);
            return Ok("Sepet değişikliği kayıt edildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            await _basketServices.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet silindi");
        }
    }
}
