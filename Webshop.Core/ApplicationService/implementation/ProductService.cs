using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;

namespace Webshop.Core.ApplicationService.implementation
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _ProductRepo;
        public ProductService(IProductRepository repo) {
            _ProductRepo = repo;
        }

        public Product CreateProduct(Product product)
        {

            return _ProductRepo.CreateProduct(product);
        }

        public Product DeleteProduct(Product product)
        {
            return _ProductRepo.DeleteProduct(product);
        }

        public Product ReadProductByID(int id)
        {
            return _ProductRepo.ReadProductByID(id);
        }

        public List<Product> ReadProducts()
        {
            return _ProductRepo.ReadProducts().ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var productUpdate = ReadProductByID(product.Id);
            productUpdate.ProductName = product.ProductName;
            productUpdate.Description = product.Description;
            productUpdate.Price = product.Price;

            return _ProductRepo.UpdateProduct(productUpdate);
        }
    }
}
