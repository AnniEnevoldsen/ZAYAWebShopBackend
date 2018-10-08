using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;

namespace Webshop.Core.ApplicationService.implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository CustomerRepository)
        {
            _customerRepository = CustomerRepository;
        }

        public Customer AddCustomer(Customer cust)
        {
           return _customerRepository.CreateCustomer(cust);
        }

        public Customer DeleteCustomer(Customer cust)
        {
           return _customerRepository.DeleteCustomer(cust);
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepository.ReadCustomerById(id);
        }

        public List<Customer> GetCustomers()
        {
           return _customerRepository.ReadCustomers().ToList();
        }

        public Customer UpdateCustomer(Customer cust)
        {
            var editCust = FindCustomerById(cust.Id);

            editCust.Id = cust.Id;
            editCust.Name = cust.Name;
            editCust.Address = cust.Address;
            editCust.Products = cust.Products;

            return _customerRepository.UpdateCustomer(editCust);
        }
    }
}
