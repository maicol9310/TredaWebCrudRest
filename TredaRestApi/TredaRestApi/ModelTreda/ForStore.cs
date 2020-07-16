using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TredaRestApi.ModelTreda
{
    public class ForStore
    {

        public int SKU { get; set; }

        public string ProductName { get; set; }

        public decimal Value { get; set; }

        public string Base64Imagen { get; set; }
    }
}
