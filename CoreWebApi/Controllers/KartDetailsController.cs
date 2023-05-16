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
    public class KartDetailsController : ControllerBase
    {
        private readonly IKartDetailsRepository _kartDetailsRepository = null;

        public KartDetailsController(IKartDetailsRepository kartDetailsRepository)
        {
            _kartDetailsRepository = kartDetailsRepository;
        }

        [HttpGet("")]
        public async Task<List<KartDetailsModel>> GetAllKartDetails()
        {
            var countryList = await _kartDetailsRepository.GetAllKartDetailsAsync();
            return countryList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetKartDetailById(int id)
        {
            var kartDetails = await _kartDetailsRepository.GetKartDetailsByIdAsync(id);

            if (kartDetails == null)
            {
                return NotFound();
            }

            return Ok(kartDetails);
        }

        [HttpPost("{kartDetailsModel}")]
        [Route("")]
        public async Task<ActionResult> AddKartDetails([FromBody] KartDetailsModel kartDetailsModel)
        {
            var id = await _kartDetailsRepository.AddKartDetailsAsync(kartDetailsModel);

            return CreatedAtAction(nameof(GetKartDetailById), new { id = id, controller = "Country" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateKartDetails([FromRoute] int id, [FromBody] KartDetailsModel kartDetailsModel)
        {
            await _kartDetailsRepository.UpdateKartDetailsAsync(id, kartDetailsModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKartDetails([FromRoute] int id)
        {
            await _kartDetailsRepository.DeleteKartDetailsAsync(id);

            return Ok();
        }
    }
}
