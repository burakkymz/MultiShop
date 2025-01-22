using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var result = _cargoCustomerService.TGetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult CustomerByIdList(int id)
        {
            var result = _cargoCustomerService.TGetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomer(CreateCargoCustomerDto cargoCustomer)
        {
            CargoCustomer customer = new CargoCustomer
            {
                Name = cargoCustomer.Name,
                Surname = cargoCustomer.Surname,
                Phone = cargoCustomer.Phone,
                Email = cargoCustomer.Email,
                Address = cargoCustomer.Address,
                District = cargoCustomer.District,
                City = cargoCustomer.City,
                UserCustomerId = cargoCustomer.UserCustomerId
            };
            _cargoCustomerService.TInsert(customer);
            return Ok("Kayıt Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kayıt Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCargoCustomerDto cargoCustomer)
        {
            CargoCustomer customer = new CargoCustomer
            {
                CargoCustomerId = cargoCustomer.CargoCustomerId,
                Name = cargoCustomer.Name,
                Surname = cargoCustomer.Surname,
                Phone = cargoCustomer.Phone,
                Email = cargoCustomer.Email,
                Address = cargoCustomer.Address,
                District = cargoCustomer.District,
                City = cargoCustomer.City,
                UserCustomerId = cargoCustomer.UserCustomerId
            };
            _cargoCustomerService.TUpdate(customer);
            return Ok("Kayıt Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id)
        {
            var result = _cargoCustomerService.TGetCargoCustomerById(id);
            return Ok(result);
        }

    }

}
