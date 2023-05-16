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
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository = null;

        public ProductTypeController(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet("")]
        public async Task<List<ProductTypeModel>> GetAllProductTypes()
        {
            var productTypeList = await _productTypeRepository.GetAllProductTypeAsync();
            return productTypeList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductTypeById(int id)
        {
            var productType = await _productTypeRepository.GetProductTypeByIdAsync(id);

            if (productType == null)
            {
                return NotFound();
            }

            return Ok(productType);
        }

        [HttpPost("{productTypeModel}")]
        [Route("")]
        public async Task<ActionResult> AddProductType([FromBody] ProductTypeModel productTypeModel)
        {
            var id = await _productTypeRepository.AddProductTypeAsync(productTypeModel);

            return CreatedAtAction(nameof(GetProductTypeById), new { id = id, controller = "ProductType" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductType([FromRoute] int id, [FromBody] ProductTypeModel productTypeModel)
        {
            await _productTypeRepository.UpdateProductTypeAsync(id, productTypeModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductType([FromRoute] int id)
        {
            await _productTypeRepository.DeleteProductTypeAsync(id);

            return Ok();
        }
    }
}
