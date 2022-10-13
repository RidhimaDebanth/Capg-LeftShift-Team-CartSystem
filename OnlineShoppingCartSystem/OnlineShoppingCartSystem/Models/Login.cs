using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Login
    {
        [Required]
        public string Username { get; set;}
       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        [Required]
        public string Role { get; set;}
    }
}
