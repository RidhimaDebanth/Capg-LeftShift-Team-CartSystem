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

        public async Task<IEnumerable<Product>> GetCart()
        {
            return  await _repository.GetCart();
        }

        public async  Task Save()
        {
            await _repository.Save();
        }
    }
}
