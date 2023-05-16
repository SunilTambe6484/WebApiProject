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
    public class SubCategoryProductMapperController : ControllerBase
    {
        private readonly ISubCategoryProductMapperRepository _subCategoryProductyMapperRepository = null;

        public SubCategoryProductMapperController(ISubCategoryProductMapperRepository subCategoryProductyMapperRepository)
        {
            _subCategoryProductyMapperRepository = subCategoryProductyMapperRepository;
        }

        [HttpGet("")]
        public async Task<List<SubCategoryProductMapperModel>> GetAllSubCategoryProductMappers()
        {
            var SubCategoryProductMapperList = await _subCategoryProductyMapperRepository.GetAllSubCategoryProductMappersAsync();
            return SubCategoryProductMapperList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubCategoryProductMapperById(int id)
        {
            var SubCategoryProductMapper = await _subCategoryProductyMapperRepository.GetSubCategoryProductMapperByIdAsync(id);

            if (SubCategoryProductMapper == null)
            {
                return NotFound();
            }

            return Ok(SubCategoryProductMapper);
        }

        [HttpPost("{countryModel}")]
        [Route("")]
        public async Task<ActionResult> AddSubCategoryProductMapper([FromBody] SubCategoryProductMapperModel subCategoryProductMapperModel)
        {
            var id = await _subCategoryProductyMapperRepository.AddSubCategoryProductMapperAsync(subCategoryProductMapperModel);

            return CreatedAtAction(nameof(GetSubCategoryProductMapperById), new { id = id, controller = "SubCategoryProductMapper" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubCategoryProductMapper([FromRoute] int id, [FromBody] SubCategoryProductMapperModel subCategoryProductMapperModel)
        {
            await _subCategoryProductyMapperRepository.UpdateSubCategoryProductMapperAsync(id, subCategoryProductMapperModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubCategoryProductMapper([FromRoute] int id)
        {
            await _subCategoryProductyMapperRepository.DeleteSubCategoryProductMapperAsync(id);

            return Ok();
        }
    }
}
