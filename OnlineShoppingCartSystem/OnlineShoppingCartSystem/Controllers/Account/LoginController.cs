using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository.Account;
using OnlineShoppingCartSystem.Services.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShoppingCartSystem.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly OnlineShoppingCartDBContext _dbContext;

        public LoginController(IConfiguration configuration,OnlineShoppingCartDBContext dBContext)
        {
            _configuration=configuration;
            _dbContext = dBContext;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            var user = Authenticate(login);
            if (user != null)
            {
                var token = Generate(user);
                var obj = new { Token = token };
                return Ok(obj);

            }
            return Ok("Failure");
        }

        private Users Authenticate(Login login)
        {
            var CurrentUser = _dbContext.Users.FirstOrDefault(
                u => u.Username == login.Username
                && u.Password==login.Password && u.Role==login.Role);
            if (CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;
        }
        private string Generate(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Password),
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_configuration["JWT:Issuer"],
                                             _configuration["JWT:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddDays(365),
                                             signingCredentials: credentials
                                             );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}


        //private readonly LoginService _loginService;
        ////private readonly LoginRepository _loginRepository;
        //public LoginController(LoginService loginService)
        //{
        //    _loginService = loginService;
        //    //_loginRepository = loginRepository;
        //}
        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate([FromBody]Login login)
        //{
        //    //var result=await _loginService.LoginAsync(login);
        //    //if(string.IsNullOrEmpty(result))
        //    //{
        //    //    return Unauthorized();
        //    //}
        //    //return Ok(result);

        //    var token=_loginService.Authenticate(login);
        //    if(token == null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(token);
        //}
    

