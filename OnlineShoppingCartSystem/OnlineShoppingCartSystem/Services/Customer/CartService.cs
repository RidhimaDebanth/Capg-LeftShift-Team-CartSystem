using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Customer;

namespace OnlineShoppingCartSystem.Services.Customer
{
    public class CartService : ICart<Product, int>
    {
        private readonly CartRepository _repository;
        public CartService(CartRepository repo)
        {
            _repository = repo;
        }

        public Task<IEnumerable<Product>> GetCart()
        {
            return _repository.GetCart();
        }

        public Task Save()
        {
            return _repository.Save();
        }
    }
}
