using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingAppService _ratingAppService;

        public RatingController(IRatingAppService ratingAppService)
        {
            _ratingAppService = ratingAppService;
        }

        [HttpGet("get-rating-list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _ratingAppService.GetAll();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet("get-rating-by-id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _ratingAppService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("register-rating")]
        public async Task<IActionResult> Create(RatingViewModel model)
        {
            var result = await _ratingAppService.Register(model);

            if (!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(Create), new { result.IsValid });
        }


        [HttpPatch("update-rating")]
        public async Task<IActionResult> Update(RatingViewModel model)
        {
            var result = await _ratingAppService.Update(model);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok(new { result.IsValid });
        }

        [HttpDelete("delete-rating")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ratingAppService.Remove(id);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok(new { result.IsValid });
        }
    }
}
