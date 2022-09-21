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
            _categoryRepository = categoryRepository;
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
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var category = await _categoryRepository.GetByName(name);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory([FromBody] Category category)
        {
            var id = await _categoryRepository.Insert(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = id, controller = "Category" }, category);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            await _categoryRepository.Update(category);
            return Ok(category);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] Category category)
        {
            await _categoryRepository.Delete(category);
            return Ok();
        }

   
     }
}
 