using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.BasketServices.Abstract;
using MultiShop.WebUI.Services.BasketServices.Concrete;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices.Abstract;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices.Concrete;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices.Abstract;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices.Concrete;
using MultiShop.WebUI.Services.CatalogServices.AboutService.Abstract;
using MultiShop.WebUI.Services.CatalogServices.AboutService.Concrete;
using MultiShop.WebUI.Services.CatalogServices.BrandService.Abstract;
using MultiShop.WebUI.Services.CatalogServices.BrandService.Concrete;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices.Abstract;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices.Concrete;
using MultiShop.WebUI.Services.CatalogServices.ContactServices.Abstract;
using MultiShop.WebUI.Services.CatalogServices.ContactServices.Concrete;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices.Abstract;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices.Concrete;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderService.Abstract;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderService.Concrete;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices.Abstract;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices.Concrete;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices.Abstract;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices.Concrete;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices.Abstract;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices.Concrete;
using MultiShop.WebUI.Services.CatalogServices.ProductServices.Abstract;
using MultiShop.WebUI.Services.CatalogServices.ProductServices.Concrete;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferService.Abstract;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferService.Concrete;
using MultiShop.WebUI.Services.CommentServices.Abstract;
using MultiShop.WebUI.Services.CommentServices.Concrete;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.DiscountServices.Abstract;
using MultiShop.WebUI.Services.DiscountServices.Concrete;
using MultiShop.WebUI.Services.MessageServices.Abstract;
using MultiShop.WebUI.Services.MessageServices.Concrete;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderOderingServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;
using MultiShop.WebUI.Services.UserIdentityServices.Abstract;
using MultiShop.WebUI.Services.UserIdentityServices.Concrete;
using MultiShop.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(
    JwtBearerDefaults.AuthenticationScheme,
    opt =>
    {
        opt.LoginPath = "/Login/Index";
        opt.LogoutPath = "/Login/Logout";
        opt.AccessDeniedPath = "/Pages/AccessDenied/";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.Cookie.Name = "jwt";
    });


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    CookieAuthenticationDefaults.AuthenticationScheme,
    opt =>
    {
        opt.LoginPath = "/Login/Index";
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        opt.Cookie.Name = "MultiShopCookie";
        opt.SlidingExpiration = true;
    });

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpClient<IIdentityService,IdentityService>();

builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));


builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

#region Catalog
builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureService, FeatureService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IBrandService, BrandService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IAboutService, AboutService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();
#endregion

//Comment
builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();


//Basket
builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

//Discount
builder.Services.AddHttpClient<IDiscountService, DiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

//Order
builder.Services.AddHttpClient<IOrderAddressService, OrderAddressService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderOderingService, OrderOderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

//Message
builder.Services.AddHttpClient<IMessageService, MessageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

//UserList
builder.Services.AddHttpClient<IUserIdentityService, UserIdentityService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

//Cargo
builder.Services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

#region Statistic
builder.Services.AddHttpClient<ICatalogStatisticService, CatalogStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IMessageStatisticService, MessageStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IDiscountStatisticService, DiscountStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IUserStatisticService, UserStatisticService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
#endregion

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
