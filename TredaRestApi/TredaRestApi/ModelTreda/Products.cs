using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TredaRestApi.ModelTreda
{
    public class Products
    {
        [Key]
        public int SKU { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public int Store { get; set; }

        [Required]
        public string Base64Imagen { get; set; }

    }
}
