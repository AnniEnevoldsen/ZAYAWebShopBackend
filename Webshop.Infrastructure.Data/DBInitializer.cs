using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.Entity;

namespace Webshop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDb(WebShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            ctx.Customer.Add(new Customer()
            {
                Name = "Heeeels"
            });

            ctx.Product.Add(new Product()
            {
                ProductName = "LadyShoes"
            });
            ctx.SaveChanges();
        }
    }
}
