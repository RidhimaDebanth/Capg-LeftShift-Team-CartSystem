//using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCartSystem.Models;

namespace OnlineShoppingCartSystem.Repository.Account
{
    public class RegisterRepository : IAccount<Users>
    {
        private readonly OnlineShoppingCartDBContext _dbContext;
        public RegisterRepository(OnlineShoppingCartDBContext _dbcontext) => this._dbContext = _dbcontext;


        #region Add User
        //Adding/Registering Customer
        public async Task<Users> Insert(Users entity)
        {
            try
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
                    //DateOfBirth = entity.DateOfBirth,
                    Password = entity.Password,
                    //ConfirmPass = entity.ConfirmPass,
                };
                _dbContext.Users.Add(u);
                await _dbContext.SaveChangesAsync();
                return u;
                //await _dbContext.Users.AddAsync(entity);
                //_dbContext.SaveChanges();
                //return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        #endregion
       
        
        #region Get methods
        //Retrieving data
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            try
            {
                //throw new NotImplementedException();
                var users = await _dbContext.Users.Select(u => new Users()
                {
                    Id = u.Id,
                    Role = u.Role,
                    Name = u.Name,
                    Username = u.Username,
                    Address = u.Address,
                    Email = u.Email,
                    PhoneNo = u.PhoneNo,
                    //DateOfBirth = u.DateOfBirth,
                    Password = u.Password,
                    //ConfirmPass = u.ConfirmPass,
                }).ToListAsync();
                return users;
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
                var user = await _dbContext.Users.Where(u => u.Id == id).Select(u => new Users()
                {
                    Id = u.Id,
                    Role = u.Role,
                    Name = u.Name,
                    Username = u.Username,
                    Address = u.Address,
                    Email = u.Email,
                    PhoneNo = u.PhoneNo,
                    //DateOfBirth = u.DateOfBirth,
                    Password = u.Password,
                    //ConfirmPass = u.ConfirmPass,

                }).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message , ex);
            }
           
        }

        public async Task<Users> GetByUsername(string username)
        {
            try
            {
                //throw new NotImplementedException();
                var user = await _dbContext.Users.Where(u => u.Username == username).Select(u => new Users()
                {
                    Id = u.Id,
                    Role = u.Role,
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
            catch(Exception ex)
            {
                throw new Exception (ex.Message , ex);
            }
        }

        #endregion


        #region Delete user account
        //Deleting user account
        public async Task DeleteUserAccount(int id)
        {
            try
            {
                //throw new NotImplementedException();
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    _dbContext.Remove(user);
                    _dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        
    }
    
}
