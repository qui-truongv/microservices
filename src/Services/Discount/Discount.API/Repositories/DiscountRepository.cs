using Dapper;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString")) ;
            var coupon = await connection.QueryFirstOrDefaultAsync("SELECT * FROM COUPON WHERE ProductName = @ProductName", new { ProductName = productName });
            return coupon;
        }
        public Task<bool> CreateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteDiscount(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
