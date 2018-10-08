using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Core.Entity;

namespace Webshop.Core
{
    public interface ICustomerService
    {
        
        //create
        Customer AddCustomer(Customer cust);

        //read
        List<Customer> GetCustomers();
        Customer FindCustomerById(int id);

        //update
        Customer UpdateCustomer(Customer cust);

        //delete
        Customer DeleteCustomer(Customer cust);
    }
}
