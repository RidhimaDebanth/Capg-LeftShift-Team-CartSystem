using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Admin;

namespace OnlineShoppingCartSystem.Services.Admin
{
    public class CategoryService 
    {
        ICategory<Category> _repository;
        public CategoryService(ICategory<Category> repo)
        {
            _repository = repo;
        }

        #region Delete Service
        //remove a category
        public async Task Delete(int id)
        {
            try
            {
                //throw new NotImplementedException();
                await _repository.Delete(id);
                //return  await _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Get methods
        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                //throw new NotImplementedException();

                return await _repository.GetAll();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public async Task<Category> GetById(int id)
        {
            try
            {
                //throw new NotImplementedException();
                return await _repository.GetById(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Category> GetByName(string name)
        {
            try
            {
                //throw new NotImplementedException();
                return await _repository.GetByName(name);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Add category
        public async Task<Category> Insert(Category entity)
        {
            try
            {
                //throw new NotImplementedException();
                return await _repository.Insert(entity);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region Update category
        public async Task<Category> Update(Category entity)
        {
            try
            {
                //throw new NotImplementedException();
                return await _repository.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
        public async Task Save()
        {
            //throw new NotImplementedException();
            await _repository.Save();
        }

        
    }


    
}
