using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class CheckoutRepository : ICheckout<Users>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public CheckoutRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;

       
        #region Update user details
        //update shipping details 
        public async Task<Users> UpdateDetails(Users entity)
        {
            try
            {
                var users = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
                if (users != null)
                {
                    users.Name = entity.Name;
                    users.PhoneNo = entity.PhoneNo;
                    users.Address = entity.Address;
                    _dbContext.SaveChanges();
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion 
       
        public async Task Save()
        {
            await  _dbContext.SaveChangesAsync();
        }
    }
}
