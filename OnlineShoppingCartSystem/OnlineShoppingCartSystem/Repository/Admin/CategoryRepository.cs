using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Admin
{
    public class CategoryRepository : ICategory<Category>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public CategoryRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;


        #region Category addition
        //Adding a new category to the database
        public async Task<Category> Insert(Category entity)
        {
            try
            {
                await _dbContext.Categories.AddAsync(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Get methods
        //Retrieving data
        /// <summary>
        /// 1.Retrieving all categories.
        /// 2.Retrieving a particular category by its category id.
        /// 3.Retrieving a particular category by its name.
        /// </summary>
        /// <returns>a list, a particular record </returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                return await _dbContext.Categories.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Category> GetById(int id)
        {
            try
            {
                var category = await _dbContext.Categories.Where(c => c.Id == id).Select(c => new Category()
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    CategoryImage = c.CategoryImage
                }).FirstOrDefaultAsync();
                return category;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            


        }

        public async Task<Category> GetByName(string name)
        {
            try
            {
                var category = await _dbContext.Categories.Where(c => c.CategoryName == name).Select(c => new Category()
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    CategoryImage= c.CategoryImage
                }).FirstOrDefaultAsync();
                return category;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        #endregion

        #region  Category Update
        //modifying the data 
        public async Task<Category> Update(Category entity)
        {
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (category != null)
                {
                    category.CategoryName = entity.CategoryName;
                    category.CategoryImage = entity.CategoryImage;
                    _dbContext.SaveChanges();

                }
                return category;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region Delete category
        //removing a category 
        public async Task Delete(int id)
        {
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (category != null)
                {
                    _dbContext.Remove(category);
                    _dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
       
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
