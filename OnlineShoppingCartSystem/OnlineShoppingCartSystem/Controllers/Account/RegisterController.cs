using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Services.Account;

namespace OnlineShoppingCartSystem.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        public readonly RegisterService _registerService;
        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUserId([FromQuery] int id)
        {
            var user = await _registerService.GetByUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Insert([Bind()] Users entity)
        {
            var r = await _registerService.Insert(entity);
            await _registerService.Save();
            return Ok(r);
        }
    }
}
