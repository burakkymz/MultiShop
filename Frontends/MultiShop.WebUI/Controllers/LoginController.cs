using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using Newtonsoft.Json;
using JsonNamingPolicy = System.Text.Json.JsonNamingPolicy;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILoginService _loginService;


        public LoginController(IHttpClientFactory clientFactory, ILoginService loginService)
        {
            _clientFactory = clientFactory;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _clientFactory.CreateClient();
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("token", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync
                            (JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        var id = _loginService.GetUserId;
                        return RedirectToAction("Index", "Default");
                    }
                }
            }

            return View();
        }
    }
}
