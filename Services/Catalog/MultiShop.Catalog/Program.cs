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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
