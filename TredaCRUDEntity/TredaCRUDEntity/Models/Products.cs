using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TredaCRUDEntity.Models
{
    public class Products
    {
        public int SKU { get; set; }
        public string ProductName { get; set; }
        public decimal Value { get; set; }
        public int Store { get; set; }
        public string Base64Imagen { get; set; }
    }
}