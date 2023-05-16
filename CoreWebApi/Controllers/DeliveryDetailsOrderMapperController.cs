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
    public class DeliveryDetailsOrderMapperController : ControllerBase
    {
        private readonly IDeliveryDetailsOrderMapperRepository _deliveryDetailsOrderMapperRepository;

        public DeliveryDetailsOrderMapperController(IDeliveryDetailsOrderMapperRepository deliveryDetailsOrderMapperRepository)
        {
            _deliveryDetailsOrderMapperRepository = deliveryDetailsOrderMapperRepository;
        }

        [HttpGet("")]
        public async Task<List<DeliveryDetailsOrderMapperModel>> GetAllDeliveryDetailsOrderMappers()
        {
            var deliveryDetailsOrderMapperList = await _deliveryDetailsOrderMapperRepository.GetAllDeliveryDetailsOrderMappersAsync();
            return deliveryDetailsOrderMapperList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDeliveryDetailsOrderMapperById(int id)
        {
            var deliveryDetailsOrderMapper = await _deliveryDetailsOrderMapperRepository.GetDeliveryDetailsOrderMapperByIdAsync(id);

            if (deliveryDetailsOrderMapper == null)
            {
                return NotFound();
            }

            return Ok(deliveryDetailsOrderMapper);
        }

        [HttpPost("{deliveryDetailsOrderMapperModel}")]
        [Route("")]
        public async Task<ActionResult> AddDeliveryDetailsOrderMapper([FromBody] DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel)
        {
            var id = await _deliveryDetailsOrderMapperRepository.AddDeliveryDetailsOrderMapperAsync(deliveryDetailsOrderMapperModel);

            return CreatedAtAction(nameof(GetDeliveryDetailsOrderMapperById), new { id = id, controller = "DeliveryDetailsOrderMapper" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDeliveryDetailsOrderMapper([FromRoute] int id, [FromBody] DeliveryDetailsOrderMapperModel deliveryDetailsOrderMapperModel)
        {
            await _deliveryDetailsOrderMapperRepository.UpdateDeliveryDetailsOrderMapperAsync(id, deliveryDetailsOrderMapperModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeliveryDetailsOrderMapper([FromRoute] int id)
        {
            await _deliveryDetailsOrderMapperRepository.DeleteDeliveryDetailsOrderMapperAsync(id);

            return Ok();
        }
    }
}
