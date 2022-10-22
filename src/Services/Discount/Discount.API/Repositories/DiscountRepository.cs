using Dapper;
using Npgsql;
using System;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
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
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (coupon == null)
                return new Coupon 
                { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };

            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            
            var affeced = await connection.ExecuteAsync("INSERT INTO COUPON (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new Coupon {ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            return affeced != 0;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affeced = await connection.ExecuteAsync("UPDATE COUPON SET ProductName = @ProductName, Description = @Description, Amount = @Amount) WHERE Id = @Id",
                new Coupon { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

            return affeced != 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affeced = await connection.ExecuteAsync("DELETE COUPON WHERE ProductName = @ProductName",
                new Coupon { ProductName = productName });

            return affeced != 0;
        }
    }
}
