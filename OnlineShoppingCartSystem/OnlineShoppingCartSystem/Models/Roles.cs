using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public string RoleName { get; set; }
    }
}
