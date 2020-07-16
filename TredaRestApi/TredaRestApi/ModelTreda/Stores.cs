using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TredaRestApi.ModelTreda
{
    public class Stores
    {

        [Key]
        public int StoreId { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Column(TypeName = "date")]
        public DateTime OpeningDate { get; set; }

    }
}
