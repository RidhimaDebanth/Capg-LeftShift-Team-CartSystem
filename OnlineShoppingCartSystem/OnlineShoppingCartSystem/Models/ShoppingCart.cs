using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
       
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public double Price { get; set; }


        [Display(Name = "Image")]
        public string Image { get; set; }


        [Display(Name = "Product Description")]
        public string Description { get; set; }
    }
}
