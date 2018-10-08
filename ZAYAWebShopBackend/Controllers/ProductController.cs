using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Core;
using Webshop.Core.Entity;

namespace ZAYAWebShopBackend.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _productService.ReadProducts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.ReadProductByID(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            return _productService.CreateProduct(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            return _productService.UpdateProduct(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var productToDelete = _productService.ReadProductByID(id);
            return _productService.DeleteProduct(productToDelete);
        }
    }
}
