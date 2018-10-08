using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Product ReadProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ReadProducts()
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
