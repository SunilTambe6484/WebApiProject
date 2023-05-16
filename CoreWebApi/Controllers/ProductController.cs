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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository = null;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<List<ProductModel>> GetAllProducts()
        {
            var productList = await _productRepository.GetAllProductsAsync();
            return productList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("{productModel}")]
        [Route("")]
        public async Task<ActionResult> AddProduct([FromBody] ProductModel productModel)
        {
            var id = await _productRepository.AddProductAsync(productModel);

            return CreatedAtAction(nameof(GetProductById), new { id = id, controller = "Product" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductModel productModel)
        {
            await _productRepository.UpdateProductAsync(id, productModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productRepository.DeleteProductAsync(id);

            return Ok();
        }
    }
}
