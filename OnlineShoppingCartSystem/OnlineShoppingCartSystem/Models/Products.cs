using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Products
    {
        [Key]
        [Display(Name ="Product ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [Display(Name = "Product Name")]
        public string  ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "price field is required")]
        [Display(Name = "Product Price")]
        public double Price { get; set; }

        [ValidateNever]
        
        public string Image { get; set; }



        [Display(Name = "Product Category Id")]
        public int CategoryId { get; set; }

        [ValidateNever]
       public Category Category { get; set; }



    }
}
