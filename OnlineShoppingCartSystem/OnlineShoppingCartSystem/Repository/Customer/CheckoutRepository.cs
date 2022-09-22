using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class CheckoutRepository : ICheckout<Users>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public CheckoutRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;

        public async Task<Users> UpdateDetails(Users entity)
        {
            var users = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id==entity.Id);
            if(users!=null)
            {
                users.Name = entity.Name;
                users.PhoneNo=entity.PhoneNo;
                users.Address = entity.Address;
                _dbContext.SaveChanges();
            }
            return users;
        }

        public async Task Save()
        {
            await  _dbContext.SaveChangesAsync();
        }
    }
}
