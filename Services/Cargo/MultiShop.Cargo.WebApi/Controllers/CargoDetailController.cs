using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CargoDetailById(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CargoDetailAdd(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail detail = new CargoDetail
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer
            };
            _cargoDetailService.TInsert(detail);
            return Ok("Kargo Detayı Başarılıyla Oluşturuldu !");
        }

        [HttpDelete]
        public IActionResult CargoDetailDelete(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Detayı Başarılıyla Silindi !");
        }

        [HttpPut]
        public IActionResult CargoDetailUpdate(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail detail = new CargoDetail
            {
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer
            };
            _cargoDetailService.TUpdate(detail);
            return Ok("Kargo Detayı Başarılıyla Güncellendi !");
        }
    }
}
