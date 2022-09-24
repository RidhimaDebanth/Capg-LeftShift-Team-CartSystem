using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Customer;

namespace OnlineShoppingCartSystem.Services.Customer
{
    public class OrderService 
    {
        IOrder<Orders> _repository;
        public OrderService(IOrder<Orders> repo)
        {
            _repository = repo;

        }
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            //throw new NotImplementedException();
            return  await _repository.GetAllOrders();
        }

        public async Task<IEnumerable<Orders>> GetOrdersByUserId(int userid)
        {
            //throw new NotImplementedException();
            return await _repository.GetOrdersByUserId(userid);
        }

        //public async Task<Orders> InsertOrder(Orders entity)
        //{
        //    //throw new NotImplementedException();
        //    return await _repository.InsertOrder(entity);
        //}

        public async Task Save()
        {
            //throw new NotImplementedException();
            await _repository.Save();
        }
    }
}
