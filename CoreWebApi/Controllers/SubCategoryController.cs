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
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository _subCategoryRepository = null;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        [HttpGet("")]
        public async Task<List<SubCategoryModel>> GetAllSubCategories()
        {
            var subCategoryList = await _subCategoryRepository.GetAllSubCategoryAsync();
            return subCategoryList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubCategoryById(int id)
        {
            var subCategory = await _subCategoryRepository.GetSubCategoryByIdAsync(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return Ok(subCategory);
        }

        [HttpPost("{subCategoryModel}")]
        [Route("")]
        public async Task<ActionResult> AddSubCategory([FromBody] SubCategoryModel subCategoryModel)
        {
            var id = await _subCategoryRepository.AddSubCategoryAsync(subCategoryModel);

            return CreatedAtAction(nameof(GetSubCategoryById), new { id = id, controller = "SubCategory" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubCategory([FromRoute] int id, [FromBody] SubCategoryModel subCategoryModel)
        {
            await _subCategoryRepository.UpdateSubCategoryAsync(id, subCategoryModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubCategory([FromRoute] int id)
        {
            await _subCategoryRepository.DeleteSubCategoryAsync(id);

            return Ok();
        }
    }
}
