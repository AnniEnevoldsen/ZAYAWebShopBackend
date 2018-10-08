
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.Entity;

namespace Webshop.Infrastructure.Data
{
    public class WebShopAppContext: DbContext
    {
        public WebShopAppContext(DbContextOptions<WebShopAppContext> option) : base(option) { }


        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }

    }
}
