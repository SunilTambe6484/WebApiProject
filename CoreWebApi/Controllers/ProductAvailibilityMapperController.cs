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
    public class ProductAvailibilityMapperController : ControllerBase
    {
        private readonly IProductAvailibilityMapperRepository _productAvailibilityMapperRepository = null;

        public ProductAvailibilityMapperController(IProductAvailibilityMapperRepository productAvailibilityMapperRepository)
        {
            _productAvailibilityMapperRepository = productAvailibilityMapperRepository;
        }

        [HttpGet("")]
        public async Task<List<ProductAvailibilityMapperModel>> GetAllProductAvailibilityMappers()
        {
            var productAvailibilityMapperList = await _productAvailibilityMapperRepository.GetAllProductAvailibilityMapperAsync();
            return productAvailibilityMapperList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductAvailibilityMapperById(int id)
        {
            var productAvailibilityMapper = await _productAvailibilityMapperRepository.GetProductAvailibilityMapperByIdAsync(id);

            if (productAvailibilityMapper == null)
            {
                return NotFound();
            }

            return Ok(productAvailibilityMapper);
        }

        [HttpPost("{productAvailibilityMapperModel}")]
        [Route("")]
        public async Task<ActionResult> AddProductAvailibilityMapper([FromBody] ProductAvailibilityMapperModel productAvailibilityMapperModel)
        {
            var id = await _productAvailibilityMapperRepository.AddProductAvailibilityMapperAsync(productAvailibilityMapperModel);

            return CreatedAtAction(nameof(GetProductAvailibilityMapperById), new { id = id, controller = "ProductAvailibilityMapper" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAvailibilityMapper([FromRoute] int id, [FromBody] ProductAvailibilityMapperModel productAvailibilityMapperModel)
        {
            await _productAvailibilityMapperRepository.UpdateProductAvailibilityMapperAsync(id, productAvailibilityMapperModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAvailibilityMapper([FromRoute] int id)
        {
            await _productAvailibilityMapperRepository.DeleteProductAvailibilityMapperAsync(id);

            return Ok();
        }
    }
}
