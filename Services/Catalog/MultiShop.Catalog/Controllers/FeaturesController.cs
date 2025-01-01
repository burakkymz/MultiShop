using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _categoriesService;

        public FeaturesController(IFeatureService featureService)
        {
            _categoriesService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var categories = await _categoriesService.GetAllFeatureAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var Feature = await _categoriesService.GetByIdFeatureAsync(id);
            return Ok(Feature);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _categoriesService.CreateFeatureAsync(createFeatureDto);
            return Ok("Başarılıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _categoriesService.DeleteFeatureAsync(id);
            return Ok("Başarılıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _categoriesService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Başarılıyla güncellendi");
        }
    }
}
