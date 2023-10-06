using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressAppService _addressAppService;

        public AddressController(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }
        [HttpGet]
        [Route("get-address-list")]
        public async Task<IActionResult> GetAddress()
        {
            var result = await _addressAppService.GetAll();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("get-address-by-id")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var result = await _addressAppService.GetById(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [Route("new-address")]
        public async Task<IActionResult> RegisterAddress(AddressViewModel viewModel) 
        {
            var result = await _addressAppService.Register(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(RegisterAddress), viewModel);
        }

        [HttpPatch]
        [Route("update-address")]
        public async Task<IActionResult> Update(AddressViewModel viewModel)
        {
            var result = await _addressAppService.Update(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return NoContent();
        }

        [HttpDelete]
        [Route("delete-address")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _addressAppService.Remove(id);

            if (!result.IsValid)
                return BadRequest(result);

            return NoContent();
        }
    }
}
