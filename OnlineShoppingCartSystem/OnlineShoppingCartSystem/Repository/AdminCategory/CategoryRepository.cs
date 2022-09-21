using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.AdminCategory
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public CategoryRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbContext;
        
        public async Task Delete(Category entity)
        {
            var category =  await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if(category != null)
            {
                _dbContext.Remove(category);
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Categories.Include(c => c.CategoryName).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        

        public async Task<Category> GetByName(string name)
        {
            return await _dbContext.Categories.FindAsync( name);
        }

        public  async Task<Category> Insert(Category entity)
        {
           await _dbContext.Categories.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }
        
        public async Task<Category> Update(Category entity)
        {
            var category=await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName==entity.CategoryName);
            if(category!=null)
            {
                category.CategoryName=entity.CategoryName;
                
            }
            return category;
        }
    }
}
