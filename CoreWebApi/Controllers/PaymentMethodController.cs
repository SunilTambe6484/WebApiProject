using CoreWebApi.Model;
using CoreWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodController(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        [HttpGet("")]
        public async Task<List<PaymentMethodModel>> GetAllPaymentMethods()
        {
            var paymentMethodList = await _paymentMethodRepository.GetAllPaymentMethodAsync();
            return paymentMethodList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPaymentMethodById(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetPaymentMethodByIdAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return Ok(paymentMethod);
        }

        [HttpPost("{paymentMethodModel}")]
        [Route("")]
        public async Task<ActionResult> AddPaymentMethod([FromBody] PaymentMethodModel paymentMethodModel)
        {
            var id = await _paymentMethodRepository.AddPaymentMethodAsync(paymentMethodModel);

            return CreatedAtAction(nameof(GetPaymentMethodById), new { id = id, controller = "PaymentMethod" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePaymentMethod([FromRoute] int id, [FromBody] PaymentMethodModel paymentMethodModel)
        {
            await _paymentMethodRepository.UpdatePaymentMethodAsync(id, paymentMethodModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaymentMethod([FromRoute] int id)
        {
            await _paymentMethodRepository.DeletePaymentMethodAsync(id);

            return Ok();
        }
    }
}
