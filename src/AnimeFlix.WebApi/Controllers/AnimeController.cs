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

        [HttpPost]
        [Route("new-anime")]
        public async Task<IActionResult> RegisterAnime(AnimeViewModel viewModel) 
        {
            var result = await _animeAppService.Register(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(RegisterAnime), viewModel);
        }
    }
}
