using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.Entity;

namespace Webshop.Core.DomainService
{
    public interface IProductRepository
    { //crud
        //Create
        Product CreateProduct(Product product);

        //Read
        IEnumerable<Product> ReadProducts();
        Product ReadProductByID(int id);

        //Update
        Product UpdateProduct(Product product);

        //Delete
        Product DeleteProduct(Product product);
    }
}
