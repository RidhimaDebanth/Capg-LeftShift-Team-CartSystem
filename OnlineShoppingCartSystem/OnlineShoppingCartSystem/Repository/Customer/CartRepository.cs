using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class CartRepository : ICart<Product, int>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public CartRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbContext;
       

        public async Task<IEnumerable<Product>> GetCart()
        {
            return await _dbContext.Products.Include(p=> p.Id).ToListAsync();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        // code updated
    }
}
