using Moq;
using System;
using System.IO;
using Webshop.Core;
using Webshop.Core.ApplicationService.implementation;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;
using Xunit;

namespace XUnitTestWebShop
{
    public class UnitTest1
    {
        [Fact]
        public void ProductDoesNotHavePrice()
        {
            var custRepo = new Mock<ICustomerRepository>();
            var productRepo = new Mock<IProductRepository>();

            IProductService service = new ProductService(productRepo.Object);

            var product = new Product()
            {
                ProductName = "Glasses"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateProduct(product));

            Assert.Equal("To create a product you need a price", ex.Message);

        }

        [Fact]
        public void ProductDoesNotHaveName()
        {
            var custRepo = new Mock<ICustomerRepository>();
            var productRepo = new Mock<IProductRepository>();

            IProductService service = new ProductService(productRepo.Object);

            var product1 = new Product()
            {
                
                Price = 45
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateProduct(product1));

            Assert.Equal("To create a product you need a product name", ex.Message);

        }
        [Fact]
        public void ProductDoesNotHaveDescription()
        {
            var custRepo = new Mock<ICustomerRepository>();
            var productRepo = new Mock<IProductRepository>();

            IProductService service = new ProductService(productRepo.Object);

            var product1 = new Product()
            {
                ProductName = "asd",
                Price = 45
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateProduct(product1));

            Assert.Equal("To create a product you need a description", ex.Message);
            

        }

        [Fact]
        public void ProductDoesNotHavePicture()
        {
            var custRepo = new Mock<ICustomerRepository>();
            var productRepo = new Mock<IProductRepository>();

            IProductService service = new ProductService(productRepo.Object);

            var product1 = new Product()
            {
                ProductName = "asd",
                Description = "qwe",
                Price = 45
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateProduct(product1));

            Assert.Equal("To create a product you need a picture", ex.Message);
            

        }

        [Fact]
        public void CustomerDoesNotHaveName()
        {
            var custRepo = new Mock<ICustomerRepository>();
            var productRepo = new Mock<IProductRepository>();

            ICustomerService service = new CustomerService(custRepo.Object);

            var customer = new Customer()
            {
                Address = "Habla"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.AddCustomer(customer));

            Assert.Equal("To create a customer you need a name", ex.Message);
        }
        [Fact]
        public void CustomerDoesNotHaveAddress()
        {
            var custRepo = new Mock<ICustomerRepository>();
            var productRepo = new Mock<IProductRepository>();

            ICustomerService service = new CustomerService(custRepo.Object);

            var customer = new Customer()
            {
                Name = "Habla"
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.AddCustomer(customer));

            Assert.Equal("To create a customer you need an address", ex.Message);
        }
    }
}
