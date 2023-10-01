using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeAppService _animeAppService;

        public AnimeController(IAnimeAppService animeAppService)
        {
            _animeAppService = animeAppService;
        }
        [HttpGet]
        [Route("get-anime-list")]
        public async Task<IActionResult> GetAnime()
        {
            var result = await _animeAppService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("get-anime-by-id")]
        public async Task<IActionResult> GetAnimeById(int id)
        {
            var result = await _animeAppService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("new-anime")]
        public async Task<IActionResult> RegisterAnime(AnimeViewModel viewModel) 
        {
            var result = await _animeAppService.Register(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(RegisterAnime), viewModel);
        }

        [HttpPatch]
        [Route("update-anime")]
        public async Task<IActionResult> Update(AnimeViewModel viewModel)
        {
            var result = await _animeAppService.Update(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok();
        }

        [HttpDelete]
        [Route("delete-anime")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _animeAppService.Remove(id);

            return Ok();
        }
    }
}
