using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.Services;
using AnimeFlix.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeAppService _episodeAppService;

        public EpisodeController(IEpisodeAppService episodeAppService)
        {
            _episodeAppService = episodeAppService;
        }

        [HttpGet("get-episode-list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _episodeAppService.GetAll();

            if(!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet("get-episode-by-id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _episodeAppService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("register-episode")]
        public async Task<IActionResult> Create(EpisodeViewModel model)
        {
            var result = await _episodeAppService.Register(model);

            if(!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(Create), new { result.IsValid });
        }


        [HttpPatch("update-episode")]
        public async Task<IActionResult> Update(EpisodeViewModel model)
        {
            var result = await _episodeAppService.Update(model);

            if (!result.IsValid)
                return BadRequest(result);
            
            return Ok(new { result.IsValid });
        }

        [HttpDelete("delete-episode")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _episodeAppService.Remove(id);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok(new { result.IsValid });
        }
    }
}
