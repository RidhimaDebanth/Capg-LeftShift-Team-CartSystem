using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Cards
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [Display(Name ="Card Owner's Name")]
        public string CardName { get; set; }

        [Required, Display(Name ="Card Number")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Please Enter Valid Card Number.")]
        public long CardNumber { get; set; }

        [Required, Display(Name ="Valid Till")]
         
        public string ExpiryDate { get; set; }

        [Required,Display(Name ="CVV")]
        [Range(0, 1000, ErrorMessage = "CVV must be a 3 digit number")]
        public int Cvv { get; set; }

    }
}
