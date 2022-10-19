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

        //[Display(Name ="Product Id")]
        //public int ProductId { get; set; }

        //[Display(Name ="Product Name")]
        //public string ProductName { get; set; }

        //[ValidateNever]
        //[Display(Name ="Image")]
        //public string ProductImage { get; set; }
        [Display(Name = "Date Of Order")]
        public DateTime DateOfOrder { get; set; }


        [Display(Name ="Mode Of Payment")]
        public string ModeOfPayment { get; set; }

        

        [Display(Name ="Bill Amount")]
        public double BillAmount { get; set; }

        [ValidateNever]
        public Users Users { get; set; }

        //[ValidateNever]
        //public Product Product { get; set; }
       
        
    }
}
