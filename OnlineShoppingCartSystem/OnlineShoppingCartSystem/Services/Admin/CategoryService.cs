using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.AdminCategory;

namespace OnlineShoppingCartSystem.Services.Admin
{
    public class CategoryService : IRepository<Category>
    {
        private readonly CategoryRepository _repository;
        public CategoryService(CategoryRepository repo)
        {
            _repository = repo;
        }

        public Task Delete(Category entity)
        {
            //throw new NotImplementedException();
            return _repository.Delete(entity);
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            //throw new NotImplementedException();
           
            return _repository.GetAll();
        }

        public Task<Category> GetById(int id)
        {
            //throw new NotImplementedException();
            return _repository.GetById(id);
        }

        public Task<Category> GetByName(string name)
        {
            //throw new NotImplementedException();
            return _repository.GetByName(name);
        }

        public Task<Category> Insert(Category entity)
        {
            //throw new NotImplementedException();
            return _repository.Insert(entity);
        }

        public async Task Save()
        {
            //throw new NotImplementedException();
            await _repository.Save();
        }

        public async Task<Category> Update(Category entity)
        {
            //throw new NotImplementedException();
            return await _repository.Update(entity);
        }
    }


    
}
