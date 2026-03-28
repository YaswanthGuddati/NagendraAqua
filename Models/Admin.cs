using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NagendraAqua.Models
{
    public class Admin
    {
        public int SellerId { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string SellerName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
      
    }
}