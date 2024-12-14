using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CargoCompanyById(int id)
        {
            var values = _cargoCompanyService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CargoCompanyAdd(CreateCargoCompanyDto cargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyName = cargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo Şirketi Başarılıyla Oluşturuldu !");
        }

        [HttpDelete]
        public IActionResult CargoCompanyDelete(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo Şirketi Başarılıyla Silindi !");
        }

        [HttpPut]
        public IActionResult CargoCompanyUpdate(UpdateCargoCompanyDto cargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyId = cargoCompanyDto.CargoCompanyId,
                CargoCompanyName = cargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo Şirketi Başarılıyla Güncellendi !");
        }
    }
}
