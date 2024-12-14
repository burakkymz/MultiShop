using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult OperationList()
        {
            var result = _cargoOperationService.TGetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult OperationById(int id)
        {
            var result = _cargoOperationService.TGetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOperation(CreateCargoOperationDto cargoOperationDto)
        {
            CargoOperation operation = new CargoOperation
            {
                Barcode = cargoOperationDto.Barcode,
                Description = cargoOperationDto.Description,
                OperationDate = cargoOperationDto.OperationDate
            };

            _cargoOperationService.TInsert(operation);
            return Ok("Operasyon oluşturuldu !");
        }

        [HttpDelete]
        public IActionResult DeleteOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Operasyon silindi !");
        }

        [HttpPut]
        public IActionResult UpdateOperation(UpdateCargoOperationDto cargoOperationDto)
        {
            CargoOperation operation = new CargoOperation
            {
                CargoOperationId = cargoOperationDto.CargoOperationId,
                Barcode = cargoOperationDto.Barcode,
                Description = cargoOperationDto.Description,
                OperationDate = cargoOperationDto.OperationDate
            };
            _cargoOperationService.TUpdate(operation);
            return Ok("Operasyon güncellendi !");
        }
    }
}
