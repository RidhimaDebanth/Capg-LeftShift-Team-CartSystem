using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class CheckoutShippingDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Phone Number field is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Phone Number.")]
        [Display(Name = "Phone Number")]
        public long PhoneNo { get; set; }


        [Required(ErrorMessage = "Address field is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
