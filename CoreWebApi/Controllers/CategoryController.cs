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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository = null;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("")]
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var categoryList = await _categoryRepository.GetAllCategoriesAsync();
            return categoryList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost("{countryModel}")]
        [Route("")]
        public async Task<ActionResult> AddCategory([FromBody] CategoryModel categoryModel)
        {
            var id = await _categoryRepository.AddCategoryAsync(categoryModel);

            return CreatedAtAction(nameof(GetCategoryById), new { id = id, controller = "Category" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryModel categoryModel)
        {
            await _categoryRepository.UpdateCategoryAsync(id, categoryModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);

            return Ok();
        }
    }
}
