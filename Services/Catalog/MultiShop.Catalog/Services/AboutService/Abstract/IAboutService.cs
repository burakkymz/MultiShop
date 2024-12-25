using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutService.Abstract
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GettAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
    }
}
