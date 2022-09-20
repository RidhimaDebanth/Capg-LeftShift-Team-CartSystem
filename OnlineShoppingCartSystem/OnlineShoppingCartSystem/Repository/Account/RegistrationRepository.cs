using OnlineShoppingCartSystem.Models;
namespace OnlineShoppingCartSystem.Repository.Account
{
    public class RegistrationRepository : IRepository<Users>
    {
        private readonly OnlineShoppingCartDBContext context;
        public RegistrationRepository(OnlineShoppingCartDBContext context) => this.context = context;


        //hie
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

        public async Task<Users> Insert(Users entity)
        {

            await context.Users.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            //throw new NotImplementedException();
            await context.SaveChangesAsync();
        }

        public Task<Users> Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}

