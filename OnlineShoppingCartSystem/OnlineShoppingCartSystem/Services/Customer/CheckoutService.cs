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

        #region Update shipping details
        public async Task<Users> UpdateDetails(Users entity)
        {
            try
            {
                return await _repository.UpdateDetails(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
      
        public async Task Save()
        {
            await _repository.Save();
        }

       
    }
}
