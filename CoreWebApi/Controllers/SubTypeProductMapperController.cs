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
    public class SubTypeProductMapperController : ControllerBase
    {
        private readonly ISubTypeProductMapperRepository _subTypeProductMapperRepository = null;

        public SubTypeProductMapperController(ISubTypeProductMapperRepository subTypeProductMapperRepository)
        {
            _subTypeProductMapperRepository = subTypeProductMapperRepository;
        }

        [HttpGet("")]
        public async Task<List<SubTypeProductMapperModel>> GetAllSubTypeProductMappers()
        {
            var subTypeProductMapperList = await _subTypeProductMapperRepository.GetAllSubTypeProductMapperAsync();
            return subTypeProductMapperList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubTypeProductMapperById(int id)
        {
            var subTypeProductMapper = await _subTypeProductMapperRepository.GetSubTypeProductMapperByIdAsync(id);

            if (subTypeProductMapper == null)
            {
                return NotFound();
            }

            return Ok(subTypeProductMapper);
        }

        [HttpPost("{subTypeProductMapperModel}")]
        [Route("")]
        public async Task<ActionResult> AddSubTypeProductMapper([FromBody] SubTypeProductMapperModel subTypeProductMapperModel)
        {
            var id = await _subTypeProductMapperRepository.AddSubTypeProductMapperAsync(subTypeProductMapperModel);

            return CreatedAtAction(nameof(GetSubTypeProductMapperById), new { id = id, controller = "SubTypeProductMapper" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubTypeProductMapper([FromRoute] int id, [FromBody] SubTypeProductMapperModel subTypeProductMapperModel)
        {
            await _subTypeProductMapperRepository.UpdateSubTypeProductMapperAsync(id, subTypeProductMapperModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubTypeProductMapper([FromRoute] int id)
        {
            await _subTypeProductMapperRepository.DeleteSubTypeProductMapperAsync(id);

            return Ok();
        }
    }
}
