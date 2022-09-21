using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;

namespace OnlineShoppingCartSystem.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly Repository.ICart<Product ,int> _CartRepository;

        public CartController(ICart<Product ,int> cartRepository)
        {
            _CartRepository = cartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var cart = await _CartRepository.GetCart();
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
        
    }
}
