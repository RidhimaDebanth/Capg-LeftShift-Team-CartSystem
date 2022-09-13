using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCartSystem.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

       
        [Display(Name ="Customers's Id")]
        public int UsersId { get; set; }   

        [Display(Name ="Product Id")]
        public int ProductId { get; set; }

        [Display(Name ="Product Name")]
        public int ProductName { get; set; }

        [ValidateNever]
        [Display(Name ="Image")]
        public string ProductImage { get; set; }
        

        [Display(Name ="Mode Of Payment")]
        public string ModeOfPayment { get; set; }

        

        [Display(Name ="Total Amount")]
        public double TotalAmount { get; set; }

        [ValidateNever]
        public Users Users { get; set; }

        [ValidateNever]
        public Product Product { get; set; }
       
        
    }
}
