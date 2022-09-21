using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Repository.Account;

namespace OnlineShoppingCartSystem.Services.Account
{
    public class UserService : IAccount<Users, int>
    {
        private readonly RegisterRepository _repository;

        public UserService(RegisterRepository repo)
        {
            _repository = repo;
        }
        public Task<Users> GetByUserId(int id)
        {
            //throw new NotImplementedException();
            return _repository.GetByUserId(id);
        }

        public Task<Users> Insert(Users entity)
        {
            //throw new NotImplementedException();
            return _repository.Insert(entity);
        }

        public Task Save()
        {
            //throw new NotImplementedException();
            return _repository.Save();
            //hi
        }
    }
}
