﻿using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandService.Abstract
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GettAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
    }
}
