using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.CategoryServices.Abstract;
using MultiShop.Catalog.Services.CategoryServices.Concrete;
using MultiShop.Catalog.Services.ProductDetailServices.Abstract;
using MultiShop.Catalog.Services.ProductDetailServices.Concrete;
using MultiShop.Catalog.Services.ProductImageServices.Abstract;
using MultiShop.Catalog.Services.ProductImageServices.Concrete;
using MultiShop.Catalog.Services.ProductServices.Abstract;
using MultiShop.Catalog.Services.ProductServices.Concrete;
using MultiShop.Catalog.Settings.Abstract;
using MultiShop.Catalog.Settings.Concrete;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureServices.Abstract;
using MultiShop.Catalog.Services.FeatureServices.Concrete;
using MultiShop.Catalog.Services.FeatureSliderService.Abstract;
using MultiShop.Catalog.Services.FeatureSliderService.Concrete;
using MultiShop.Catalog.Services.SpecialOfferService.Abstract;
using MultiShop.Catalog.Services.SpecialOfferService.Concrete;
using MultiShop.Catalog.Services.OfferDiscountServices.Abstract;
using MultiShop.Catalog.Services.OfferDiscountServices.Concrete;
using MultiShop.Catalog.Services.BrandService.Abstract;
using MultiShop.Catalog.Services.BrandService.Concrete;
using MultiShop.Catalog.Services.AboutService.Abstract;
using MultiShop.Catalog.Services.AboutService.Concrete;
using MultiShop.Catalog.Services.ContactServices.Abstract;
using MultiShop.Catalog.Services.ContactServices.Concrete;
using MultiShop.Catalog.Services.StatisticServices.Abstract;
using MultiShop.Catalog.Services.StatisticServices.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority=builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IDatabaseSettings>(provider =>
{
    return provider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
