using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.Entity;
using Webshop.Core.Entity.Entities;

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
        List<Product> GetFilteredProducts(Filter filter);

        //Update
        Product UpdateProduct(Product product);

        //Delete
        Product DeleteProduct(Product product);
    }
}
