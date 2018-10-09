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

            var product = ctx.Product.Add(new Product()
            {
                ProductName = "LadyShoes",
                Picture = "http://fp2w.org/assets/ext/blob.jpg",
                Gender = "Male",
                Type = "Glasses"
            }).Entity;

            var product2 = ctx.Product.Add(new Product()
            {
                ProductName = "Nighttime",
                Picture = "http://fp2w.org/assets/ext/blob.jpg"
            }).Entity;

            var product3 = ctx.Product.Add(new Product()
            {
                ProductName = "Hello"
            }).Entity;

            var product4 = ctx.Product.Add(new Product()
            {
                ProductName = "Bugger"
            }).Entity;

            ctx.Customer.Add(new Customer()
            {
                Name = "Heeeels",
                Products = product              
            });

            ctx.SaveChanges();
        }
    }
}
