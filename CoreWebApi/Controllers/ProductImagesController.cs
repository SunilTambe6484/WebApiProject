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
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImagesRepository _productImagesRepository = null;

        public ProductImagesController(IProductImagesRepository productImagesRepository)
        {
            _productImagesRepository = productImagesRepository;
        }

        [HttpGet("")]
        public async Task<List<ProductImagesModel>> GetAllProductImages()
        {
            var productImagesList = await _productImagesRepository.GetAllProductImagesAsync();
            return productImagesList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductImagesById(int id)
        {
            var productImages = await _productImagesRepository.GetProductImagesByIdAsync(id);

            if (productImages == null)
            {
                return NotFound();
            }

            return Ok(productImages);
        }

        [HttpPost("{productImagesModel}")]
        [Route("")]
        public async Task<ActionResult> AddProductImages([FromBody] ProductImagesModel productImagesModel)
        {
            var id = await _productImagesRepository.AddProductImagesAsync(productImagesModel);

            return CreatedAtAction(nameof(GetProductImagesById), new { id = id, controller = "ProductImages" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductImages([FromRoute] int id, [FromBody] ProductImagesModel productImagesModel)
        {
            await _productImagesRepository.UpdateProductImagesAsync(id, productImagesModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductImages([FromRoute] int id)
        {
            await _productImagesRepository.DeleteProductImagesAsync(id);

            return Ok();
        }
    }
}
