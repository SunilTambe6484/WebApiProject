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
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public OrderHistoryController(IOrderHistoryRepository orderHistoryRepository)
        {
            _orderHistoryRepository = orderHistoryRepository;
        }

        [HttpGet("")]
        public async Task<List<OrderHistoryModel>> GetAllOrderHistories()
        {
            var orderHistoryList = await _orderHistoryRepository.GetAllOrderHistoriesAsync();
            return orderHistoryList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderHistoryById(int id)
        {
            var orderHistory = await _orderHistoryRepository.GetOrderHistoryByIdAsync(id);

            if (orderHistory == null)
            {
                return NotFound();
            }

            return Ok(orderHistory);
        }

        [HttpPost("{orderHistoryModel}")]
        [Route("")]
        public async Task<ActionResult> AddOrderHistory([FromBody] OrderHistoryModel orderHistoryModel)
        {
            var id = await _orderHistoryRepository.AddOrderHistoryAsync(orderHistoryModel);

            return CreatedAtAction(nameof(GetOrderHistoryById), new { id = id, controller = "OrderHistory" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderHistory([FromRoute] int id, [FromBody] OrderHistoryModel orderHistoryModel)
        {
            await _orderHistoryRepository.UpdateOrderHistoryAsync(id, orderHistoryModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderHistory([FromRoute] int id)
        {
            await _orderHistoryRepository.DeleteOrderHistoryAsync(id);

            return Ok();
        }
    }
}
