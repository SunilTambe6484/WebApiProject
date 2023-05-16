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
    public class ProductSubTypeController : ControllerBase
    {
        private readonly IProductSubTypeRepository _productSubTypeRepository = null;

        public ProductSubTypeController(IProductSubTypeRepository productSubTypeRepository)
        {
            _productSubTypeRepository = productSubTypeRepository;
        }

        [HttpGet("")]
        public async Task<List<ProductSubTypeModel>> GetAllProductSubTypes()
        {
            var productSubTypeList = await _productSubTypeRepository.GetAllProductSubTypeAsync();
            return productSubTypeList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductSubTypeById(int id)
        {
            var productSubType = await _productSubTypeRepository.GetProductSubTypeByIdAsync(id);

            if (productSubType == null)
            {
                return NotFound();
            }

            return Ok(productSubType);
        }

        [HttpPost("{productSubTypeModel}")]
        [Route("")]
        public async Task<ActionResult> AddProductSubType([FromBody] ProductSubTypeModel productSubTypeModel)
        {
            var id = await _productSubTypeRepository.AddProductSubTypeAsync(productSubTypeModel);

            return CreatedAtAction(nameof(GetProductSubTypeById), new { id = id, controller = "ProductSubType" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductSubType([FromRoute] int id, [FromBody] ProductSubTypeModel productSubTypeModel)
        {
            await _productSubTypeRepository.UpdateProductSubTypeAsync(id, productSubTypeModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductSubType([FromRoute] int id)
        {
            await _productSubTypeRepository.DeleteProductSubTypeAsync(id);

            return Ok();
        }
    }
}
