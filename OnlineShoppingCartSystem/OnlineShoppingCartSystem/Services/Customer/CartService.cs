using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Customer;

namespace OnlineShoppingCartSystem.Services.Customer
{
    public class CartService  
    {
        ICart<Product, int> _repository;
        public CartService(ICart<Product, int> repo)
        {
            _repository = repo;
        }


        #region Get Cart 
        public async Task<IEnumerable<Product>> GetCart()
        {
            try
            {
                return await _repository.GetCart();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
     
        public async  Task Save()
        {
            await _repository.Save();
        }
    }
}
