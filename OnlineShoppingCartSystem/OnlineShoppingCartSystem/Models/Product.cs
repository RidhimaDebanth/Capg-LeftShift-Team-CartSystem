using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Product
    {
        [Key]
        [Display(Name ="Product ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [Display(Name = "Product Name")]
        public string  Name { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "price field is required")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [ValidateNever]
        public string ProductImage { get; set; }

        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [ValidateNever]
       public Category Category { get; set; }



    }
}
