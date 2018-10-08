using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.Entity;

namespace Webshop.Core
{
    public interface IProductService
    {
        //crud
        //Create
        Product CreateProduct(Product product);

        //Read
        List<Product> ReadProducts();
        Product ReadProductByID(int id);

        //Update
        Product UpdateProduct(Product product);

        //Delete
        Product DeleteProduct(Product product);
    }
}
