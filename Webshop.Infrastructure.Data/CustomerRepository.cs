using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;

namespace Webshop.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly WebShopAppContext _ctx;

        public CustomerRepository(WebShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Customer CreateCustomer(Customer customer)
        {
            
            _ctx.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(Customer customer)
        {
            _ctx.SaveChanges();
            return customer;
        }

        public Customer ReadCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ReadCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _ctx.SaveChanges();
            return customer;
        }
    }
}
