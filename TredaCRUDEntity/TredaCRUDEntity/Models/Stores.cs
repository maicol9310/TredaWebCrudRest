using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TredaCRUDEntity.Models
{
    public class Stores
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime OpeningDate { get; set; }
    }
}