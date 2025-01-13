using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class productContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }
    }
}