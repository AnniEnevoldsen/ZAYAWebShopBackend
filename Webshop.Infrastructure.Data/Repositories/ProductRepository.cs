using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;

namespace Webshop.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        readonly WebShopAppContext _ctx;
        public ProductRepository(WebShopAppContext ctx) {
            _ctx = ctx;
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
            return _ctx.Product.FirstOrDefault( p => p.Id == id);
            
        }

        public IEnumerable<Product> ReadProducts()
        {
            return _ctx.Product;
        }

        public Product UpdateProduct(Product product)
        {
            _ctx.Update(product);
            _ctx.SaveChanges();
            return product;
        }
    }
}
