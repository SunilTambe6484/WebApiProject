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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository = null;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        
        [HttpGet("")]
        public async Task<List<CountryModel>> GetAllCountries()
        {
            var countryList = await _countryRepository.GetAllCountriesAsync();
            return countryList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCountryById(int id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);

            if(country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost("{countryModel}")]
        [Route("")]
        public async Task<ActionResult> AddCountry([FromBody]CountryModel countryModel)
        {
            var id = await _countryRepository.AddCountryAsync(countryModel);

            return CreatedAtAction(nameof(GetCountryById), new { id = id, controller = "Country"} );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCountry([FromRoute]int id, [FromBody] CountryModel countryModel)
        {
            await _countryRepository.UpdateCountryAsync(id, countryModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry([FromRoute] int id)
        {
            await _countryRepository.DeleteCountryAsync(id);

            return Ok();
        }
    }
}
