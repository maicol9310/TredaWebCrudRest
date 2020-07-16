using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TredaRestApi.ModelTreda;

namespace TredaRestApi.Contexts
{
    public class TredaDbContext : DbContext
    {
        public TredaDbContext(DbContextOptions<TredaDbContext> options) : base(options)
        {
        }

        public DbSet<Stores> Stores {get; set;}

        public DbSet<Products> Products { get; set; }
    }
}
