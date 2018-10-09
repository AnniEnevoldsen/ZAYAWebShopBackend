using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Core;
using Webshop.Core.Entity;

namespace ZAYAWebShopBackend.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetCustomers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _customerService.FindCustomerById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            try
            {
                return Ok(_customerService.AddCustomer(customer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            try
            {
                return _customerService.UpdateCustomer(customer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            var custDelete = _customerService.FindCustomerById(id);
            _customerService.DeleteCustomer(custDelete);

            return Ok($"Customer with id {id} was deleted");
        }
    }
}
