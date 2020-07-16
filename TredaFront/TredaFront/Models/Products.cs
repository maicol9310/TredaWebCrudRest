using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TredaFront.Models
{
    public class Products
    {
        [Display(Name = "SKU")]
        public int SKU { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Value")]
        public decimal Value { get; set; }

        [Display(Name = "Store")]
        public int Store { get; set; }
    }
}