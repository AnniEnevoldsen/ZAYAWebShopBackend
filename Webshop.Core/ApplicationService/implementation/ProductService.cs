using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;

namespace Webshop.Core.ApplicationService.implementation
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _ProductRepo;
        public ProductService(IProductRepository productRepo) {
            _ProductRepo = productRepo;

        }

        public Product CreateProduct(Product product)
        {
            if (product.Price <= 0)
                throw new InvalidDataException("To create a product you need a price");
            if (product.ProductName == "" || product.ProductName == null)
                throw new InvalidDataException("To create a product you need a product name");
            if (product.Description == "" || product.Description == null)
                throw new InvalidDataException("To create a product you need a description");
            if (product.Picture == "" || product.Picture == null)
                throw new InvalidDataException("To create a product you need a picture");
            if (product.Gender == "" || product.Gender == null)
                throw new InvalidDataException("To create a product you need a gender");
            if (product.Type == "" || product.Type == null)
                throw new InvalidDataException("To create a product you need a type");


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
            if (product.Price <= 0)
                throw new InvalidDataException("To update a product you need a price");
            if (product.ProductName == "" || product.ProductName == null)
                throw new InvalidDataException("To update a product you need a product name");
            if (product.Description == "" || product.Description == null)
                throw new InvalidDataException("To update a product you need a description");
            if (product.Picture == "" || product.Picture == null)
                throw new InvalidDataException("To update a product you need a picture");
            if (product.Gender == "" || product.Gender == null)
                throw new InvalidDataException("To update a product you need a gender");
            if (product.Type == "" || product.Type == null)
                throw new InvalidDataException("To update a product you need a type");

            var productUpdate = ReadProductByID(product.Id);
            productUpdate.ProductName = product.ProductName;
            productUpdate.Description = product.Description;
            productUpdate.Price = product.Price;
            productUpdate.Gender = product.Gender;
            productUpdate.Type = product.Type;
            productUpdate.Picture = product.Picture;


            return _ProductRepo.UpdateProduct(productUpdate);
        }
    }
}
