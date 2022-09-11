using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Name field is required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
