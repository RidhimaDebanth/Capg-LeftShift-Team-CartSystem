using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class OrderRepository : IOrder<Orders, int>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public OrderRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbContext;
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _dbContext.Orders.Include(o => o.UsersId)
                                          .Include(o => o.ProductId)
                                          .Include(o => o.ProductName)
                                          .Include(o => o.ProductImage)
                                          .Include(o => o.ModeOfPayment)
                                          .Include(o => o.TotalAmount)
                                          .ToListAsync();
        }

        public async Task<Orders> GetOrderById(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }

        public async Task<Orders> InsertOrder(Orders entity)
        {
            await _dbContext.Orders.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
