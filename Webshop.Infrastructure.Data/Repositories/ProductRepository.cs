using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;
using Webshop.Core.Entity.Entities;

namespace Webshop.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        readonly WebShopAppContext _ctx;
        public ProductRepository(WebShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public int Count()
        {
            return _ctx.Product.Count();
        }

        public Product CreateProduct(Product product)
        {
            var createdProduct = _ctx.Product.Add(product).Entity;
            _ctx.SaveChanges();
            return createdProduct;
        }

        public Product DeleteProduct(Product product)
        {
            var deletedProduct = _ctx.Product.Remove(product).Entity;
            _ctx.SaveChanges();
            return deletedProduct;
        }

        public Product ReadProductByID(int id)
        {
            return _ctx.Product.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> ReadProducts(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Product;
            }
            return _ctx.Product
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Product UpdateProduct(Product product)
        {
            _ctx.Update(product);
            _ctx.SaveChanges();
            return product;
        }
    }
}
