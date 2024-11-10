using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Services.Concrete
{
    public class DiscountServices : IDiscountServices
    {
        private readonly DapperContext _dapperContext;

        public DiscountServices(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CrateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) " +
                           "VALUES (@code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
