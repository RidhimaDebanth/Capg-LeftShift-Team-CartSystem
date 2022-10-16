using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class CartRepository : ICart<Product, int>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public CartRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;

        #region GetCart
        //get cart products
        public async Task<IEnumerable<Product>> GetCart()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
