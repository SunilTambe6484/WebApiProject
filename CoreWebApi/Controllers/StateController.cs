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
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository = null;

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet("")]
        public async Task<List<StateModel>> GetAllStates()
        {
            var stateList = await _stateRepository.GetAllStatesAsync();
            return stateList;
        }

        [HttpGet]
        [Route("GetStateById/{id}")]
        //[ActionName("StateById")]
        public async Task<ActionResult> GetStateById([FromRoute]int id)
        {
            var state = await _stateRepository.GetStateByIdAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        [HttpGet]
        [Route("GetStatesByCountryId/{countryId}")]
        //[ActionName("StatesByCountryId")]
        public async Task<ActionResult> GetStatesByCountryId([FromRoute]int countryId)
        {
            var stateList = await _stateRepository.GetStateByCountryIdAsync(countryId);

            if (stateList == null)
            {
                return NotFound();
            }

            return Ok(stateList);
        }

        [HttpPost("{stateModel}")]
        [Route("")]
        public async Task<ActionResult> AddState([FromBody] StateModel stateModel)
        {
            var id = await _stateRepository.AddStateAsync(stateModel);

            return CreatedAtAction(nameof(GetStateById), new { id = id, controller = "State" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateState([FromRoute] int id, [FromBody] StateModel stateModel)
        {
            await _stateRepository.UpdateStateAsync(id, stateModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteState([FromRoute] int id)
        {
            await _stateRepository.DeleteStateAsync(id);

            return Ok();
        }
    }
}
