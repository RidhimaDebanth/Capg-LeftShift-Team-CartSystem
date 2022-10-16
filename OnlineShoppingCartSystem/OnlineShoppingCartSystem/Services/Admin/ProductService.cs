using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Admin;

namespace OnlineShoppingCartSystem.Services.Admin
{
    public class ProductService
    {
        IProduct<Product> _repository;
        public ProductService(IProduct<Product> repo)
        {
            _repository = repo;
        }

        #region Delete product
        public async Task Delete(int id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Get methods
        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _repository.GetById(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  async Task<IEnumerable<Product> >GetByName(string name)
        {
            try
            {
                return await _repository.GetByName(name);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
        {
            try
            {
                return await _repository.GetByCategoryId(categoryId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

       
        #region Add a product
        public async  Task<Product> Insert(Product entity)
        {
            try
            {
                return await _repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Update product
        public async Task<Product> Update(Product entity)
        {
            try
            {
                return await _repository.Update(entity);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
      
        public async Task Save()
        {
             await _repository.Save();  
        }

       
    }
}
