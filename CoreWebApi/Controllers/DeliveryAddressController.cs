using CoreWebApi.DL;
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
    public class DeliveryAddressController : ControllerBase
    {
        private readonly IDeliveryAddressRepository _deliveryAddressRepository = null;

        public DeliveryAddressController(IDeliveryAddressRepository deliveryAddressRepository)
        {
            _deliveryAddressRepository = deliveryAddressRepository;
        }

        [HttpGet("")]
        public async Task<List<DeliveryAddressModel>> GetAllDeliveryAddresses()
        {
            var deliveryAddressList = await _deliveryAddressRepository.GetAllDeliveryAddressesAsync();
            return deliveryAddressList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDeliveryAddressById(int id)
        {
            var deliveryAddress = await _deliveryAddressRepository.GetDeliveryAddressByIdAsync(id);

            if (deliveryAddress == null)
            {
                return NotFound();
            }

            return Ok(deliveryAddress);
        }

        [HttpPost("{deliveryAddressModel}")]
        [Route("")]
        public async Task<ActionResult> AddDeliveryAddress([FromBody] DeliveryAddressModel deliveryAddressModel)
        {
            var id = await _deliveryAddressRepository.AddDeliveryAddressAsync(deliveryAddressModel);

            return CreatedAtAction(nameof(GetDeliveryAddressById), new { id = id, controller = "DeliveryAddress" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDeliveryAddress([FromRoute] int id, [FromBody] DeliveryAddressModel deliveryAddressModel)
        {
            await _deliveryAddressRepository.UpdateDeliveryAddressAsync(id, deliveryAddressModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeliveryAddress([FromRoute] int id)
        {
            await _deliveryAddressRepository.DeleteDeliveryAddressAsync(id);

            return Ok();
        }
    }
}
