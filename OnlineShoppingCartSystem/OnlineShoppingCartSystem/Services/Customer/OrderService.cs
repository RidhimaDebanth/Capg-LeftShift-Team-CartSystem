using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Customer;

namespace OnlineShoppingCartSystem.Services.Customer
{
    public class OrderService : IOrder<Orders, int>
    {
        private readonly OrderRepository _repository;
        public OrderService(OrderRepository repo)
        {
            _repository = repo;

        }
        public Task<IEnumerable<Orders>> GetAllOrders()
        {
            //throw new NotImplementedException();
            return _repository.GetAllOrders();
        }

        public Task<Orders> GetOrderById(int id)
        {
            //throw new NotImplementedException();
            return _repository.GetOrderById(id);
        }

        public Task<Orders> InsertOrder(Orders entity)
        {
            //throw new NotImplementedException();
            return _repository.InsertOrder(entity);
        }

        public Task Save()
        {
            //throw new NotImplementedException();
            return _repository.Save();
        }
    }
}
