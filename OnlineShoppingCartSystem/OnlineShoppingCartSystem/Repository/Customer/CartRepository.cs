using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class CartRepository : ICart<Product, int>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public CartRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;
       

        public async Task<IEnumerable<Product>> GetCart()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
