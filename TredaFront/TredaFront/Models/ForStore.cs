using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TredaFront.Models
{
    public class ForStore
    {
        [Display(Name = "SKU")]
        public int SKU { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Value")]
        public decimal Value { get; set; }

        [Display(Name = "Base 64 Imagen")]
        public string Base64Imagen { get; set; }
    }
}