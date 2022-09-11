using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Name field is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }

       public string Address { get; set; }

       [Required(ErrorMessage ="Email Address is required")]
       [EmailAddress]
        public string Email { get; set; }
       
        [Required(ErrorMessage ="Phone Number is required")]
        [Display(Name="Phone Number")]
        public long PhoneNo { get; set; }

        [Display(Name="Date of Birth")]
        public DateTime DateOfBirth { get; set; }
      
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage ="Password length is inappropriate")]
        public string Password { get; set; }
       
        [Required]
        [Display(Name="Confirm Password")]
        [StringLength (100, ErrorMessage ="Password length is inappropriate")]
        [DataType(DataType.Password)]  
        public string  ConfirmPass { get; set; }

        [Required]
        [Display (Name="Role Id")]
        public int RoleId { get; set; }

        [ValidateNever]
        public Roles Roles { get; set; }

    }
}
