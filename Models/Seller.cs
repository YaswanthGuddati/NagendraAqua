using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NagendraAqua.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        [Required(ErrorMessage = "Seller name is required")]
        public string SellerName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}