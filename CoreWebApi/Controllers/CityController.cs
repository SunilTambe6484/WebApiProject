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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository = null;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet("")]
        public async Task<List<CityModel>> GetAllCities()
        {
            var cityList = await _cityRepository.GetAllCitiesAsync();
            return cityList;
        }

        [HttpGet("{id}")]
        [Route("GetCityById/{id}")]
        public async Task<ActionResult> GetCityById(int id)
        {
            var city = await _cityRepository.GetCityByIdAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpGet]
        [Route("GetCitiesByStateId/{stateId}")]
        public async Task<ActionResult> GetCitiesByStateId([FromRoute] int stateId)
        {
            var cityList = await _cityRepository.GetCityByStateIdAsync(stateId);

            if (cityList == null)
            {
                return NotFound();
            }

            return Ok(cityList);
        }

        [HttpPost("{cityModel}")]
        [Route("")]
        public async Task<ActionResult> AddCity([FromBody] CityModel cityModel)
        {
            var id = await _cityRepository.AddCityAsync(cityModel);

            return CreatedAtAction(nameof(GetCityById), new { id = id, controller = "City" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCountry([FromRoute] int id, [FromBody] CityModel cityModel)
        {
            await _cityRepository.UpdateCityAsync(id, cityModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCity([FromRoute] int id)
        {
            await _cityRepository.DeleteCityAsync(id);

            return Ok();
        }
    }
}
