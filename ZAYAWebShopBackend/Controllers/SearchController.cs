using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Core;
using Webshop.Core.Entity;

namespace ZAYAWebShopBackend.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : Controller
    {
        readonly IProductService _productService;

        public SearchController(IProductService productService)
        {
            _productService = productService;

        }

        // GET name of product
        [HttpGet("{productName}")]
        public ActionResult<Product> Get(string productName)
        {
            return _productService.ReadProductByName(productName);
        }

    }
}