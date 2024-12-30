using System.Security.Claims;

namespace MultiShop.WebUI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId
        {
            get
            {
                if (_httpContextAccessor.HttpContext?.User?.Identity.IsAuthenticated == true)
                {
                    return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                }

                return null;
            }
        }
    }
}
