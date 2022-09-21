using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;

namespace OnlineShoppingCartSystem.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly Repository.IAccount<Users, int> _registerRepository;
        public RegisterController(IAccount<Users, int> registerRepository)
        {
            _registerRepository = registerRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var user = await _registerRepository.GetByUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Users entity)
        {
            var id = await _registerRepository.Insert(entity);
            return CreatedAtAction(nameof(GetByUserId), new { id = id, controller = "Register" }, id);
        }
    }
}
