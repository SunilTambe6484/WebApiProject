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
    public class DeliveryDetailsController : ControllerBase
    {
        private readonly IDeliveryDetailsRepository _deliveryDetailsRepository = null;

        public DeliveryDetailsController(IDeliveryDetailsRepository deliveryDetailsRepository)
        {
            _deliveryDetailsRepository = deliveryDetailsRepository;
        }

        [HttpGet("")]
        public async Task<List<DeliveryDetailsModel>> GetAllDeliveryDetails()
        {
            var deliveryDetailsList = await _deliveryDetailsRepository.GetAllDeliveryDetailsAsync();
            return deliveryDetailsList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDeliveryDetailsById(int id)
        {
            var deliveryDetails = await _deliveryDetailsRepository.GetDeliveryDetailsByIdAsync(id);

            if (deliveryDetails == null)
            {
                return NotFound();
            }

            return Ok(deliveryDetails);
        }

        [HttpPost("{countryModel}")]
        [Route("")]
        public async Task<ActionResult> AddDeliveryDetails([FromBody] DeliveryDetailsModel deliveryDetailsModel)
        {
            var id = await _deliveryDetailsRepository.AddDeliveryDetailsAsync(deliveryDetailsModel);

            return CreatedAtAction(nameof(GetDeliveryDetailsById), new { id = id, controller = "DeliveryDetails" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDeliveryDetails([FromRoute] int id, [FromBody] DeliveryDetailsModel deliveryDetailsModel)
        {
            await _deliveryDetailsRepository.UpdateDeliveryDetailsAsync(id, deliveryDetailsModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeliveryDetails([FromRoute] int id)
        {
            await _deliveryDetailsRepository.DeleteDeliveryDetailsAsync(id);

            return Ok();
        }
    }
}
