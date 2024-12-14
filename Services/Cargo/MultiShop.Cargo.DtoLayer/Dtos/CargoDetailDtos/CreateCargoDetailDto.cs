using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public class CreateCargoDetailDto
    {
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
        public CargoCompany CargoCompany { get; set; }
    }
}
