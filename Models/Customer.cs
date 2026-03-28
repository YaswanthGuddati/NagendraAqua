using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NagendraAqua.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^[6-9]\d{9}$",
        ErrorMessage = "Mobile must start with 6,7,8,9 and contain 10 digits")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please select feed type")]
        public int FeedId { get; set; }
        [Required(ErrorMessage = "Customer category required")]
        public string CustomerType { get; set; }
        [Required(ErrorMessage = "Please select seller")]
        public int SellerId { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100000, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
}