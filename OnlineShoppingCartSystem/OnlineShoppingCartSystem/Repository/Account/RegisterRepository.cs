//using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Account
{
    public class RegisterRepository : IAccount<Users>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public RegisterRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;


        #region Methods
        public async Task<Users> Insert(Users entity)
        {
            var role = "Customer";
            var u = new Users()
            {
                Id = entity.Id,
                Role = role,
                Name = entity.Name,
                Username = entity.Username,
                Address = entity.Address,
                Email = entity.Email,
                PhoneNo = entity.PhoneNo,
                DateOfBirth = entity.DateOfBirth,
                Password = entity.Password,
                ConfirmPass = entity.ConfirmPass,
            };
            _dbContext.Users.Add(u);
            await _dbContext.SaveChangesAsync();
            return u;
            //await _dbContext.Users.AddAsync(entity);
            //_dbContext.SaveChanges();
            //return entity;
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            //throw new NotImplementedException();
            var users=await _dbContext.Users.Select(u=> new Users()
            {
                Id = u.Id,
                Role = u.Role,
                Name = u.Name,
                Username = u.Username,
                Address = u.Address,
                Email = u.Email,
                PhoneNo = u.PhoneNo,
                DateOfBirth = u.DateOfBirth,
                Password = u.Password,
                ConfirmPass = u.ConfirmPass,
            }).ToListAsync();
            return users;
        }

        public async Task<Users> GetByUserId(int id)
        {
            var user = await _dbContext.Users.Where(u => u.Id == id).Select(u => new Users()
            {
                Id = u.Id,
                Role = u.Role,
                Name = u.Name,
                Username = u.Username,
                Address = u.Address,
                Email = u.Email,
                PhoneNo = u.PhoneNo,
                DateOfBirth = u.DateOfBirth,
                Password = u.Password,
                ConfirmPass = u.ConfirmPass,

            }).FirstOrDefaultAsync(); 
            return user;    
        }

        public async Task<Users> GetByUsername(string username)
        {
            //throw new NotImplementedException();
            var user = await _dbContext.Users.Where(u => u.Username == username).Select(u => new Users()
            {
                Id = u.Id,
                Name = u.Name,
                Username = u.Username,
                Address = u.Address,
                //Email = u.Email,
                PhoneNo = u.PhoneNo,
                //DateOfBirth = u.DateOfBirth,
                //Password = u.Password,
                //ConfirmPass = u.ConfirmPass,

            }).FirstOrDefaultAsync();
            return user;
        }

        public async Task DeleteUserAccount(Users entity)
        {
            //throw new NotImplementedException();
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
            if ( user!= null)
            {
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
            }
        }



        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        
    }
    #endregion
}
