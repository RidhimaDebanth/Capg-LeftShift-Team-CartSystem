using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Services;
using OnlineShoppingCartSystem.Services.Admin;

namespace OnlineShoppingCartSystem.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        //private readonly IRepository<Category> _categoryRepository;
        public readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory([Bind()] Category entity)
        {
            await _categoryService.Insert(entity);
            await _categoryService.Save();
            return (Ok());

        }



        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromQuery] int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var category = await _categoryService.GetByName(name);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //[HttpPost]
        //public async Task<IActionResult> InsertCategory([FromBody] Category category)
        //{
        //    var id = await _categoryRepository.Insert(category);
        //    return CreatedAtAction(nameof(GetCategoryById), new { id = id, controller = "Category" }, category);

        //}

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            await _categoryService.Update(category);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory( int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }


    }
}
 