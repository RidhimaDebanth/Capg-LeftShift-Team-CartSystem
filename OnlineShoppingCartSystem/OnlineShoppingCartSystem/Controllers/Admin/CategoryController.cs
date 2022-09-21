using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;

namespace OnlineShoppingCartSystem.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
 