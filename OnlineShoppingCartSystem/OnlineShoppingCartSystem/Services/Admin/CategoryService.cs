using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.AdminCategory;

namespace OnlineShoppingCartSystem.Services.Admin
{
    public class CategoryService 
    {
        ICategory<Category> _repository;
        public CategoryService(ICategory<Category> repo)
        {
            _repository = repo;
        }

        public async Task Delete(Category entity)
        {
            //throw new NotImplementedException();
             await _repository.Delete(entity);
            //return  await _repository.Delete(entity);
            
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            //throw new NotImplementedException();
           
            return await _repository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            //throw new NotImplementedException();
            return await _repository.GetById(id);
        }

        public async Task<Category> GetByName(string name)
        {
            //throw new NotImplementedException();
            return await _repository.GetByName(name);
        }

        public async Task<Category> Insert(Category entity)
        {
            //throw new NotImplementedException();
            return await _repository.Insert(entity);


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
