using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Services.Admin;

namespace OnlineShoppingCartSystem.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var products = await _productService.GetByName(name);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);

        }



        [HttpPost]
        public async Task<IActionResult> InsertProduct([Bind()] Product entity)
        {
            await _productService.Insert(entity);
            await _productService.Save();
            return (Ok());


        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            await _productService.Update(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }

        [HttpGet("{categoryId:int}/categoryitems")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var product = await _productService.GetByCategoryId(categoryId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
