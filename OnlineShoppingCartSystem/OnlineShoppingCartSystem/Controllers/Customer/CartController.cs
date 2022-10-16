using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Services.Customer;

namespace OnlineShoppingCartSystem.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly CartService _cartService;
        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            try
            {
                var cart = await _cartService.GetCart();
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
    }
}
