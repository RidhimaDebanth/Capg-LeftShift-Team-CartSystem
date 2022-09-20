using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class OrderRepository : IRepository<Orders>
    {
        private readonly OnlineShoppingCartDBContext context;

        public OrderRepository(OnlineShoppingCartDBContext context) => this.context = context;


        public async Task<Orders> Insert(Orders entity)
        {
            await context.Orders.AddAsync(entity);
            return entity;
        }

        public async Task<Orders> GetById(int id)
        {
            return await context.Orders.FindAsync(id);
        }






        public Task Delete(Orders entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Orders>> GetAll()
        {
            throw new NotImplementedException();
        }



        public Task<Orders> GetByName(string name)
        {
            throw new NotImplementedException();
        }



        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public Task<Orders> Update(Orders entity)
        {
            throw new NotImplementedException();
        }
    }
}
