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

        #region Get methods
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            try
            {
                //throw new NotImplementedException();
                return await _repository.GetAllOrders();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
      
        public async Task<IEnumerable<Orders>> GetOrdersByUserId(int userid)
        {
            try
            {
                //throw new NotImplementedException();
                return await _repository.GetOrdersByUserId(userid);
            }
            catch(Exception ex)
            {
                throw  new Exception(ex.Message, ex);
            }
        }

        #endregion


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
