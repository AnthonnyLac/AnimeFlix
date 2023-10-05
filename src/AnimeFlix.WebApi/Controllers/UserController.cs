using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [Route("get-user-by-id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userAppService.GetById(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [Route("new-user")]
        public async Task<IActionResult> RegisterUser(UserViewModel viewModel) 
        {
            var result = await _userAppService.Register(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return CreatedAtAction(nameof(RegisterUser), viewModel);
        }

        [HttpPatch]
        [Route("update-user")]
        public async Task<IActionResult> Update(UserViewModel viewModel)
        {
            var result = await _userAppService.Update(viewModel);

            if (!result.IsValid)
                return BadRequest(result);

            return NoContent();
        }

        [HttpDelete]
        [Route("delete-user")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userAppService.Delete(id);

            if (!result.IsValid)
                return BadRequest(result);

            return NoContent();
        }
    }
}
