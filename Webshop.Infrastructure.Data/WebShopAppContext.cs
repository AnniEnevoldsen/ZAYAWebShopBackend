
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Webshop.Core.Entity;

namespace Webshop.Infrastructure.Data
{
    public class WebShopAppContext: DbContext
    {
        

        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }

    }
}
