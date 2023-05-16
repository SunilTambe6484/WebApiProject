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
    public class ProductDeliveryExpectationController : ControllerBase
    {
        private readonly IProductDeliveryExpectationRepository _productDeliveryExpectationRepository;

        public ProductDeliveryExpectationController(IProductDeliveryExpectationRepository productDeliveryExpectationRepository)
        {
            _productDeliveryExpectationRepository = productDeliveryExpectationRepository;
        }

        [HttpGet("")]
        public async Task<List<ProductDeliveryExpectationModel>> GetAllProductDeliveryExpectations()
        {
            var productDeliveryExpectationsList = await _productDeliveryExpectationRepository.GetAllProductDeliveryExpectationAsync();
            return productDeliveryExpectationsList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductDeliveryExpectationById(int id)
        {
            var productDeliveryExpectation = await _productDeliveryExpectationRepository.GetProductDeliveryExpectationByIdAsync(id);

            if (productDeliveryExpectation == null)
            {
                return NotFound();
            }

            return Ok(productDeliveryExpectation);
        }

        [HttpPost("{countryModel}")]
        [Route("")]
        public async Task<ActionResult> AddProductDeliveryExpectation([FromBody] ProductDeliveryExpectationModel productDeliveryExpectationModel)
        {
            var id = await _productDeliveryExpectationRepository.AddProductDeliveryExpectationAsync(productDeliveryExpectationModel);

            return CreatedAtAction(nameof(GetProductDeliveryExpectationById), new { id = id, controller = "ProductDeliveryExpectation" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductDeliveryExpectation([FromRoute] int id, [FromBody] ProductDeliveryExpectationModel productDeliveryExpectationModel)
        {
            await _productDeliveryExpectationRepository.UpdateProductDeliveryExpectationAsync(id, productDeliveryExpectationModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductDeliveryExpectation([FromRoute] int id)
        {
            await _productDeliveryExpectationRepository.DeleteProductDeliveryExpectationAsync(id);

            return Ok();
        }
    }
}
