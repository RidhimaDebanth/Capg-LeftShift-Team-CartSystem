using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.AdminProduct;

namespace OnlineShoppingCartSystem.Services.Admin
{
    public class ProductService : IRepository<Product>
    {
        private readonly ProductRepository _repository;
        public ProductService(ProductRepository repo)
        {
            _repository = repo;
        }

        public Task Delete(Product entity)
        {
            return _repository.Delete(entity);
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Product> GetById(int id)
        {
           return _repository.GetById(id);
        }

        public Task<Product> GetByName(string name)
        {
           return _repository.GetByName(name);
        }

        public Task<Product> Insert(Product entity)
        {
           return _repository.Insert(entity);
        }

        public Task Save()
        {
            return _repository.Save();  
        }

        public Task<Product> Update(Product entity)
        {
            return _repository.Update(entity);
        }
    }
}
