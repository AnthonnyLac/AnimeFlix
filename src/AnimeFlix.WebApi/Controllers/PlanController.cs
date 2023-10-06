using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.WebApi.Controllers
{
    public class PlanController : ControllerBase
    {
        private readonly IPlanAppService _planAppService;

        public PlanController(IPlanAppService planAppService)
        {
            _planAppService = planAppService;
        }

        [HttpGet("get-plan-list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _planAppService.GetAll();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet("get-plan-by-id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _planAppService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("register-plan")]
        public async Task<IActionResult> Create(PlanViewModel model)
        {
            var result = await _planAppService.Register(model);

            if (!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(Create), new { result.IsValid });
        }


        [HttpPatch("update-plan")]
        public async Task<IActionResult> Update([FromBody] PlanViewModel model)
        {
            var result = await _planAppService.Update(model);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok(new { result.IsValid });
        }

        [HttpDelete("delete-plan")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _planAppService.Remove(id);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok(new { result.IsValid });
        }
    }
}
