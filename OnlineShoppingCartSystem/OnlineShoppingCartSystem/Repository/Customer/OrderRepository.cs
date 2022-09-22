using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class OrderRepository : IOrder<Orders, int>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public OrderRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Orders> GetOrderById(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }

        public async Task<Orders> InsertOrder(Orders entity)
        {
            await _dbContext.Orders.AddAsync(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
