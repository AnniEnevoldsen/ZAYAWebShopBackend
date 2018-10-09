using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.Entity;
using Webshop.Core.Entity.Entities;

namespace Webshop.Core.DomainService
{
    public interface IProductRepository
    { //crud
        //Create
        Product CreateProduct(Product product);

        //Read
        IEnumerable<Product> ReadProducts(Filter filter = null);
        Product ReadProductByID(int id);

        //Update
        Product UpdateProduct(Product product);

        //Delete
        Product DeleteProduct(Product product);

        int Count();
    }
}
