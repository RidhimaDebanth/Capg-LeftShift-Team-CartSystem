using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        public async Task<IActionResult> Insert([Bind()] Users entity)
        {
            var r = await _registerService.Insert(entity);
            await _registerService.Save();
            return Ok(r);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _registerService.GetAllUsers();
            return Ok(users);
        }




        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByUserId( int id)
        {
            var user = await _registerService.GetByUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        

        [HttpGet("{username}")]
        public async Task<IActionResult>GetByUsername(string username)
        {
            var user = await _registerService.GetByUsername(username);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAccount([FromBody] Users user)
        {
            await _registerService.DeleteUserAccount(user);
            return Ok();
        }
    }
}
