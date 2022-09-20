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
            
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == entity.Id);
            if (product != null)
            {
                context.Remove(entity);
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
           
            return await context.Products.Include(p => p.Id)
                                            .Include(p => p.Name)
                                            .Include(p => p.ProductDescription)
                                            .Include(p => p.Price)
                                            .Include(p => p.ProductImage)
                                            .Include(p => p.CategoryId)
                                            .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            
            return await context.Products.FindAsync(id);
        }

        public async Task<Product> GetByName(string name)
        {
            
            return await context.Products.FindAsync(name);
        }

        public async Task<Product> Insert(Product entity)
        {

            await context.Products.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            
            await context.SaveChangesAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            //throw new NotImplementedException();
            var product = await context.Products.FirstOrDefaultAsync(p => p.Name == entity.Name);
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

