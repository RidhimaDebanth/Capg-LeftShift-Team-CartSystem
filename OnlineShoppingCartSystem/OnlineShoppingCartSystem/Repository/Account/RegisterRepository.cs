//using Microsoft.Identity.Client;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Account
{
    public class RegisterRepository : IAccount<Users , int>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public RegisterRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbContext;
        public async Task<Users> GetByUserId(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<Users> Insert(Users entity)
        {
            await _dbContext.Users.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
