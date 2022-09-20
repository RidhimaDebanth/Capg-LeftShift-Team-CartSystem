using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.AdminProduct
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly OnlineShoppingCartDBContext context;
        public ProductRepository(OnlineShoppingCartDBContext context) => this.context = context;

        public async Task Delete(Product entity)
        {
            //throw new NotImplementedException();
            var product = await context.Products.FirstOrDefaultAsync(b => b.Id == entity.Id);
            if (product != null)
            {
                context.Remove(entity);
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            //throw new NotImplementedException();
            return await context.Products.Include(b => b.Id)
                                            .Include(b => b.Name)
                                            .Include(b => b.ProductDescription)
                                            .Include(b => b.Price)
                                            .Include(b => b.ProductImage)
                                            .Include(b => b.CategoryId)
                                             .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            //throw new NotImplementedException();
            return await context.Products.FindAsync(id);
        }

        public async Task<Product> GetByName(string name)
        {
            //throw new NotImplementedException();
            return await context.Products.FindAsync(name);
        }

        public async Task<Product> Insert(Product entity)
        {
            //throw new NotImplementedException();
            await context.Products.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            //throw new NotImplementedException();
            await context.SaveChangesAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            //throw new NotImplementedException();
            var product = await context.Products.FirstOrDefaultAsync(b => b.Name == entity.Name);
            if (product != null)
            {
                product.Name = entity.Name;
                product.ProductDescription = entity.ProductDescription;
                product.Price = entity.Price;
                product.ProductImage = entity.ProductImage;
                product.CategoryId = entity.CategoryId;

            }
            return product;
        }
    }
}

