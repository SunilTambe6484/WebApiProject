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
    public class ProductSpecificationController : ControllerBase
    {
        private readonly IProductSpecificationRepository _productSpecificationRepository = null;

        public ProductSpecificationController(IProductSpecificationRepository productSpecificationRepository)
        {
            _productSpecificationRepository = productSpecificationRepository;
        }

        [HttpGet("")]
        public async Task<List<ProductSpecificationModel>> GetAllProductSpecifications()
        {
            var productSpecificationList = await _productSpecificationRepository.GetAllProductSpecificationAsync();
            return productSpecificationList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductSpecificationById(int id)
        {
            var productSpecification = await _productSpecificationRepository.GetProductSpecificationByIdAsync(id);

            if (productSpecification == null)
            {
                return NotFound();
            }

            return Ok(productSpecification);
        }

        [HttpPost("{productSpecificationModel}")]
        [Route("")]
        public async Task<ActionResult> AddProductSpecification([FromBody] ProductSpecificationModel productSpecificationModel)
        {
            var id = await _productSpecificationRepository.AddProductSpecificationAsync(productSpecificationModel);

            return CreatedAtAction(nameof(GetProductSpecificationById), new { id = id, controller = "ProductSpecification" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductSpecification([FromRoute] int id, [FromBody] ProductSpecificationModel productSpecificationModel)
        {
            await _productSpecificationRepository.UpdateProductSpecificationAsync(id, productSpecificationModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductSpecification([FromRoute] int id)
        {
            await _productSpecificationRepository.DeleteProductSpecificationAsync(id);

            return Ok();
        }
    }
}
