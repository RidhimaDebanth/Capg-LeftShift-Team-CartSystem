using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;

namespace OnlineShoppingCartSystem.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var categories = await _productRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
