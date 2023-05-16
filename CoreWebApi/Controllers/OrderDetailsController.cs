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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository = null;

        public OrderDetailsController(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        [HttpGet("")]
        public async Task<List<OrderDetailsModel>> GetAllOrderDetails()
        {
            var orderDetailsList = await _orderDetailsRepository.GetAllOrderDetailsAsync();
            return orderDetailsList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderDetailsById(int id)
        {
            var orderDetails = await _orderDetailsRepository.GetOrderDetailsByIdAsync(id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }

        [HttpPost("{orderDetailsModel}")]
        [Route("")]
        public async Task<ActionResult> AddOrderDetails([FromBody] OrderDetailsModel orderDetailsModel)
        {
            var id = await _orderDetailsRepository.AddOrderDetailsAsync(orderDetailsModel);

            return CreatedAtAction(nameof(GetOrderDetailsById), new { id = id, controller = "OrderDetails" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderDetails([FromRoute] int id, [FromBody] OrderDetailsModel orderDetailsModel)
        {
            await _orderDetailsRepository.UpdateOrderDetailsAsync(id, orderDetailsModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderDetails([FromRoute] int id)
        {
            await _orderDetailsRepository.DeleteOrderDetailsAsync(id);

            return Ok();
        }
    }
}
