using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Customer
{
    public class CheckoutRepository : IRepository<Users>
    {
        private readonly OnlineShoppingCartDBContext context;

        public CheckoutRepository(OnlineShoppingCartDBContext context) => this.context = context;


        public async Task<Users> Update(Users entity)
        {
            var Users = await context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
            if (Users != null)
            {
                Users.Name = entity.Name;
                Users.Address = entity.Address;
                Users.PhoneNo = entity.PhoneNo;

            }
            return Users;

        }



        public Task Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Users> Insert(Users entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}
