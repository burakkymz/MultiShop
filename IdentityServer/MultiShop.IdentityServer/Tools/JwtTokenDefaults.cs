namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost"; // Dinleyici
        public const string ValidIssuer = "http://localhost"; // Yayıncı
        public const string Key = "MultiShop..0102030405Asp.NetCore8.0.11*/+-";
        public const int Expire = 60;
    }
}
