using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Customer;

namespace OnlineShoppingCartSystem.Services.Customer
{
    public class OrderService 
    {
        IOrder<Orders, int> _repository;
        public OrderService(IOrder<Orders, int> repo)
        {
            _repository = repo;

        }
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            //throw new NotImplementedException();
            return  await _repository.GetAllOrders();
        }

        public async Task<Orders> GetOrderById(int id)
        {
            //throw new NotImplementedException();
            return await _repository.GetOrderById(id);
        }

        public async Task<Orders> InsertOrder(Orders entity)
        {
            //throw new NotImplementedException();
            return await _repository.InsertOrder(entity);
        }

        public async Task Save()
        {
            //throw new NotImplementedException();
            await _repository.Save();
        }
    }
}
