using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.AdminProduct;

namespace OnlineShoppingCartSystem.Services.Admin
{
    public class ProductService
    {
        IProduct<Product> _repository;
        public ProductService(IProduct<Product> repo)
        {
            _repository = repo;
        }

        public async Task Delete(Product entity)
        {
            await _repository.Delete(entity);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
           return await _repository.GetById(id);
        }

        public  async Task<IEnumerable<Product> >GetByName(string name)
        {
           return  await _repository.GetByName(name);
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
        {
            return await _repository.GetByCategoryId(categoryId);
        }

        public async  Task<Product> Insert(Product entity)
        {
           return await  _repository.Insert(entity);
        }

        public async Task Save()
        {
             await _repository.Save();  
        }

        public async Task<Product> Update(Product entity)
        {
            return  await _repository.Update(entity);
        }
    }
}
