using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;

namespace OnlineShoppingCartSystem.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly Repository.ICheckout<Users> _CheckoutRepository;
        public CheckoutController(ICheckout<Users> CheckoutRepository)
        {
            _CheckoutRepository = CheckoutRepository;

        }

        [HttpPut]
        public async Task<IActionResult> UpdateDetails([FromBody] Users users )

        {
          await _CheckoutRepository.UpdateDetails(users);
          return Ok(users);
        }

       
    }
}
