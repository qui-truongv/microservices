﻿using System;
using System.Net;
using Discount.API.Entities;
using System.Threading.Tasks;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{productName}", Name ="GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName)
        {
            var coupon = await _repository.GetDiscount(productName);
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
        {
            var isSuccess = await _repository.CreateDiscount(coupon);
            return isSuccess ? CreatedAtRoute("GetDiscount", new {productName = coupon.ProductName }, coupon) : NotFound();
        }

        public async Task<ActionResult> UpdateDiscount(Coupon coupon)
        {
            var isSuccess = await _repository.UpdateDiscount(coupon);
            return isSuccess ? Ok() : NotFound();
        }

        [HttpDelete("{productName}", Name ="DeleteDiscount")]
        [ProducesResponseType(typeof(void),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteDiscount(string productName)
        {
            return Ok(await _repository.DeleteDiscount(productName));
        }
    }
}
