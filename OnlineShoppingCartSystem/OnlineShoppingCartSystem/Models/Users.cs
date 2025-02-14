﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        

        [Display(Name = "Role")]
        public string Role { get; set; } 

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }

       public string Address { get; set; }

       [Required(ErrorMessage ="Email Address is required")]
       [EmailAddress]
        public string Email { get; set; }
       
        [Required(ErrorMessage ="Phone Number is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Phone Number.")]
        [Display(Name="Phone Number")]
        public long PhoneNo { get; set; }

        //[Display(Name="Date of Birth")]
        //public DateTime DateOfBirth { get; set; }
      
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage ="Password length is inappropriate")]
        public string Password { get; set; }
       
        //[Required]
        //[Display(Name="Confirm Password")]
        //[StringLength (100, ErrorMessage ="Password length is inappropriate")]
        //[DataType(DataType.Password)]  
        //public string  ConfirmPass { get; set; }

        

        

    }
}
