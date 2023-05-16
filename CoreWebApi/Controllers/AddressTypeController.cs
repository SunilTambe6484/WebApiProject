using CoreWebApi.DL;
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
    public class AddressTypeController : ControllerBase
    {
        private readonly IAddressTypeRepository _addressTypeRepository = null;

        public AddressTypeController(IAddressTypeRepository addressTypeRepository)
        {
            _addressTypeRepository = addressTypeRepository;
        }

        [HttpGet("")]
        public async Task<List<AddressTypeModel>> GetAllAddressTypes()
        {
            var addressTypeList = await _addressTypeRepository.GetAllAddressTypesAsync();
            return addressTypeList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAddressTypeById(int id)
        {
            var addressType = await _addressTypeRepository.GetAddressTypeByIdAsync(id);

            if (addressType == null)
            {
                return NotFound();
            }

            return Ok(addressType);
        }

        [HttpPost("{countryModel}")]
        [Route("")]
        public async Task<ActionResult> AddAddressType([FromBody] AddressTypeModel addressTypeModel)
        {
            var id = await _addressTypeRepository.AddAddressTypeAsync(addressTypeModel);

            return CreatedAtAction(nameof(GetAddressTypeById), new { id = id, controller = "AddressType" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAddressType([FromRoute] int id, [FromBody] AddressTypeModel addressTypeModel)
        {
            await _addressTypeRepository.UpdateAddressTypeAsync(id, addressTypeModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddressType([FromRoute] int id)
        {
            await _addressTypeRepository.DeleteAddressTypeAsync(id);

            return Ok();
        }
    }
}
