using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.Entity;

namespace Webshop.Core.DomainService
{
    public interface ICustomerRepository
    {
        
        //create
        Customer CreateCustomer(Customer customer);

        //read
        IEnumerable<Customer> ReadCustomers();
        Customer ReadCustomerById(int id);

        //update
        Customer UpdateCustomer(Customer customer);

        //delete
        Customer DeleteCustomer(Customer customer);
        
        
    }
}
