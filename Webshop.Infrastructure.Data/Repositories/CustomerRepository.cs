using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;
using System.Linq;

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
            _ctx.Attach(customer).State = EntityState.Added;
            _ctx.SaveChanges();

            return customer;
        }

        public Customer DeleteCustomer(Customer customer)
        {
            _ctx.Remove(customer);  
            _ctx.SaveChanges();
            return customer;
        }

        public Customer ReadCustomerById(int id)
        {
            return _ctx.Customer.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> ReadCustomers()
        {
            return _ctx.Customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _ctx.Update(customer);
            _ctx.SaveChanges();
            return customer;
        }
    }
}
