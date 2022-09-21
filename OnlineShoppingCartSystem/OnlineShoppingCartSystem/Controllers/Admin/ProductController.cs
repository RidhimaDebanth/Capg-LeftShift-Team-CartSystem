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
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _productRepository.GetByName(name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] Product product)
        {
            var id = await _productRepository.Insert(product);
            return CreatedAtAction(nameof(GetProductById), new { id = id, controller = "Product" }, product);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct( [FromBody] Product product)
        {
            await _productRepository.Update(product);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] Product product)
        {
            await _productRepository.Delete(product);
            return Ok();
        }
    }
}
