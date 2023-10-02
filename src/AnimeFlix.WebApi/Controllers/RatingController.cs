using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create()
        {
            // Lógica de criação
            return CreatedAtAction(nameof(Get), new { id = 1 });
        }

        [HttpGet("{id}")]
        public IActionResult Get()
        {
            // Lógica de obtenção por ID
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok();
        }

        [HttpPatch]
        public IActionResult Update()
        {

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            return NoContent();
        }
    }
}
