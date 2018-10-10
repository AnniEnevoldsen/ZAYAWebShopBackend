using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Core;
using Webshop.Core.Entity;
using Webshop.Core.Entity.Entities;

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
        public ActionResult<IEnumerable<Product>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
                {
                    return Ok(_productService.ReadProducts());
                }
                return Ok(_productService.GetFilteredProducts(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            // remember to add: ?CurrentPage=1&ItemsPrPage=3 
            //the pagenumber and itemsprpage can be changed.
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.ReadProductByID(id);
        }

        // GET api/values/5
        [HttpGet("{gender}")]
        public ActionResult<IEnumerable<Product>> Get(string gender)
        {
            return _productService.ReadProductsByGender(gender);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            try
            {
                return _productService.CreateProduct(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            try
            {
                return _productService.UpdateProduct(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
