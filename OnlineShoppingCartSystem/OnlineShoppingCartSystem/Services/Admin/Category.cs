using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository.AdminCategory;

namespace OnlineShoppingCartSystem.Services.Admin
{
    public class Category : CategoryRepository
    {
        private readonly CategoryRepository CategoryRepo;

        public Category(OnlineShoppingCartDBContext CategoryRepo)
        {
            CategoryRepo = CategoryRepo;
        }
        public async  Task<IEnumerable<Category>> GetAllCategories()
        {
            return  await CategoryRepo.CreatGetAll()).ToListAsync();
            
        }


    }
}
