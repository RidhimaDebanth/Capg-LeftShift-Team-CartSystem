using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class CartRepository : IRepository<Product>
    {
        private readonly OnlineShoppingCartDBContext context;

        public CartRepository(OnlineShoppingCartDBContext context) => this.context = context;

        public async Task Delete(Product entity)
        {
            var Product = await context.Products.FirstOrDefaultAsync(p => p.Id == entity.Id);
            if (Product != null)
            {
                context.Remove(Product);
            }
        }







        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }



        public Task<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }

    }
}
