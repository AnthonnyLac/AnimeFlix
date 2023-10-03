using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterAppService _characterAppService;

        public CharacterController(ICharacterAppService characterAppService)
        {
            _characterAppService = characterAppService;
        }

        [HttpGet("get-character-list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _characterAppService.GetAll();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet("get-character-by-id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _characterAppService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("register-character")]
        public async Task<IActionResult> Create(CharacterViewModel characterViewModel)
        {
            var result = await _characterAppService.Register(characterViewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(Create), new { Data = characterViewModel});
        }


        [HttpPatch("update-character")]
        public async Task<IActionResult> Update(CharacterViewModel characterViewModel)
        {
            var result = await _characterAppService.Update(characterViewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return NoContent();
        }

        [HttpDelete("delete-character")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _characterAppService.Remove(id);

            if (!result.IsValid)
                return BadRequest(result);

            return NoContent();
        }
    }
}
