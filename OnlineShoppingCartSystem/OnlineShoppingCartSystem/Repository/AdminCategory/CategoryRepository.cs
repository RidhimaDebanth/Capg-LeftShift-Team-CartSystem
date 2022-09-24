using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.AdminCategory
{
    public class CategoryRepository : ICategory<Category>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public CategoryRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;




        public async Task<Category> Insert(Category entity)
        {
            await _dbContext.Categories.AddAsync(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        #region Get
        //Retrieving data
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _dbContext.Categories.Where(c => c.Id== id).Select(c => new Category()
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
            }).FirstOrDefaultAsync();
            return category;
            
            


        }

        

        public async Task<Category> GetByName(string name)
        {
            var category= await _dbContext.Categories.Where(c=> c.CategoryName ==name).Select(c => new Category()
            {
                Id=c.Id,
                CategoryName = c.CategoryName
            }).FirstOrDefaultAsync();
            return category;
            
        }

        #endregion
        
        public async Task<Category> Update(Category entity)
        {
            var category=await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id==entity.Id);
            if(category!=null)
            {
                category.CategoryName=entity.CategoryName;
                _dbContext.SaveChanges();
                
            }
            return category;
        }
        
        public async Task Delete(Category entity)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (category != null)
            {
                _dbContext.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
