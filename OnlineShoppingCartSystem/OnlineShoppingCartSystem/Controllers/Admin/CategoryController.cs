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
            try
            {
                await _categoryService.Insert(entity);
                await _categoryService.Save();
                return (Ok());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }



        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAll();
                return Ok(categories);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromQuery] int id)
        {
            try {
                var category = await _categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            try
            {
                var category = await _categoryService.GetByName(name);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
            
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
            try
            {
                await _categoryService.Update(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory( int id)
        {
            try
            {
                await _categoryService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


    }
}
 