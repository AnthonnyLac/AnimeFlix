using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionAppService _subscriptionAppService;

        public SubscriptionController(ISubscriptionAppService subscriptionAppService)
        {
            _subscriptionAppService = subscriptionAppService;
        }
        [HttpGet]
        [Route("get-subscription-list")]
        public async Task<IActionResult> GetAddress()
        {
            var result = await _subscriptionAppService.GetAll();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("get-subscription-by-id")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var result = await _subscriptionAppService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [Route("new-subscription")]
        public async Task<IActionResult> RegisterAddress(SubscriptionViewModel viewModel)
        {
            var result = await _subscriptionAppService.Register(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(RegisterAddress), viewModel);
        }

        [HttpPatch]
        [Route("update-subscription")]
        public async Task<IActionResult> Update(SubscriptionViewModel viewModel)
        {
            var result = await _subscriptionAppService.Update(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return NoContent();
        }

        [HttpDelete]
        [Route("delete-subscription")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _subscriptionAppService.Remove(id);

            if (!result.IsValid)
                return BadRequest(result);

            return NoContent();
        }
    }
}
