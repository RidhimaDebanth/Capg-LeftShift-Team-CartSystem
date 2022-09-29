using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Services.Customer;

namespace OnlineShoppingCartSystem.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        public readonly CheckoutService _checkoutService;
        public CheckoutController(CheckoutService categoryService)
        {
            _checkoutService = categoryService;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateDetails([FromBody] Users users )

        {
          await _checkoutService.UpdateDetails(users);
          return Ok(users);
        }

       
    }
}
