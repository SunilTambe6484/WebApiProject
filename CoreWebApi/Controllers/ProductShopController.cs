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
    public class ProductShopController : ControllerBase
    {
        private readonly IProductShopRepository _productShopRepository = null;

        public ProductShopController(IProductShopRepository productShopRepository)
        {
            _productShopRepository = productShopRepository;
        }

        [HttpGet("")]
        public async Task<List<ProductShopModel>> GetAllProductShops()
        {
            var productShopList = await _productShopRepository.GetAllProductShopsAsync();
            return productShopList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductShopById(int id)
        {
            var productShop = await _productShopRepository.GetProductShopByIdAsync(id);

            if (productShop == null)
            {
                return NotFound();
            }

            return Ok(productShop);
        }

        [HttpPost("{productShopModel}")]
        [Route("")]
        public async Task<ActionResult> AddProductShop([FromBody] ProductShopModel productShopModel)
        {
            var id = await _productShopRepository.AddProductShopAsync(productShopModel);

            return CreatedAtAction(nameof(GetProductShopById), new { id = id, controller = "ProductShop" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductShop([FromRoute] int id, [FromBody] ProductShopModel productShopModel)
        {
            await _productShopRepository.UpdateProductShopAsync(id, productShopModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductShop([FromRoute] int id)
        {
            await _productShopRepository.DeleteProductShopAsync(id);

            return Ok();
        }
    }
}
