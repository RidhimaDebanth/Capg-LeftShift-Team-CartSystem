using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Customer;

namespace OnlineShoppingCartSystem.Services.Customer
{
    public class CheckoutService : ICheckout<Users>
    {
        private readonly CheckoutRepository _repository;
        public CheckoutService(CheckoutRepository repo)
        {
            _repository = repo;
        }
        public Task Save()
        {
            return _repository.Save();
        }

        public async Task<Users> UpdateDetails(Users entity)
        {
            return await _repository.UpdateDetails(entity);
        }
    }
}
