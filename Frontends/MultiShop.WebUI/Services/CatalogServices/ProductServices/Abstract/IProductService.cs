﻿using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices.Abstract
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<ResultProductDto> GetProductByIdAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryDto();
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string CategoryID);
    }
}
