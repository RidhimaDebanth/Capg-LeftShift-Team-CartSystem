using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Account;

namespace OnlineShoppingCartSystem.Services.Account
{
    public class RegisterService 
    {
        IAccount<Users> _repository;

        public RegisterService(IAccount<Users> repo)
        {
            _repository = repo;
        }

        #region Add Customer
        public async Task<Users> Insert(Users entity)
        {
            try
            {
                //throw new NotImplementedException();
                return await _repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Get methods
        //retrieving of data
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            try
            {
                return await _repository.GetAllUsers();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Users> GetByUserId(int id)
        {
            try
            {
                //throw new NotImplementedException();
                return await _repository.GetByUserId(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        public async Task<Users> GetByUsername(string username)
        {
            try
            {
                return await _repository.GetByUsername(username);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Delete User Account
        //remove user account
        public async Task DeleteUserAccount (int id)
        {
            try
            {
                await _repository.DeleteUserAccount(id);
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message, ex);
            }
        }
        #endregion

        public Task Save()
        {
            //throw new NotImplementedException();
            return  _repository.Save();
            
        }
    }
}
