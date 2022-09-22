using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Customer;

namespace OnlineShoppingCartSystem.Services.Customer
{
    public class CheckoutService  
    {
        ICheckout<Users> _repository;
        public CheckoutService(ICheckout<Users> repo)
        {
            _repository = repo;
        }
        public async Task Save()
        {
            await _repository.Save();
        }

        public async Task<Users> UpdateDetails(Users entity)
        {
            return await _repository.UpdateDetails(entity);
        }
    }
}
