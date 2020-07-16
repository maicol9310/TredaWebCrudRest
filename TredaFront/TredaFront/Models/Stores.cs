using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TredaFront.Models
{
    public class Stores
    {
        [Display(Name = "Store Id")]
        public int StoreId { get; set; }

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [Display(Name = "Openin Date")]
        public DateTime OpeningDate { get; set; }
    }
}