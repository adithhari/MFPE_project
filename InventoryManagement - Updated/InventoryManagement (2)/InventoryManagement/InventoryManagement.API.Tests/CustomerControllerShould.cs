using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using InventoryManagement.API;
using InventoryManagement.API.Controllers;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.API.DTOs;
using InventoryManagement.Domain.Aggregates.InventoryAggregates;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Moq;

namespace InventoryManagement.API.Tests
{
    [TestFixture]
    public class CustomerControllerShould
    {
        [Test]
        public async Task Return_201StatusCode()
        {
            var dto = new CustomerDTO()
            {
                Fullname = "Revathy",
                PhoneNumber = "9874325896",
                Address = "Avadi",

            };
            var repo = new Mock<IRepository<Customer>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var repoObj = repo.Object;

            var controller = new CustomersController(repoObj);

            var result = (StatusCodeResult)await controller.AddCustomer(dto).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(201));
        }
        [Test]
        public void Return_200StatusCode_ShouldReturnAllCustomers()
        {

            var repo = new Mock<IRepository<Customer>>();
            string name = "Deena K";
            string phone = "9997166369";
            string address = "Chennai";

            repo.Setup(m => m.Get()).Returns(() => {
                var customer = new Customer(name, phone, address);
                return new List<Customer>() { customer };

            });


            var repoObj = repo.Object;

            var controller = new CustomersController(repoObj);
            OkObjectResult result = (OkObjectResult)controller.GetCustomers();
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public void Return_200StatusCode_ValidCustomerId()
        {
            var repo = new Mock<IRepository<Customer>>();
            string name = "Deena K";
            string phone = "9997166369";
            string address = "Chennai";
            repo.Setup(m => m.GetById(It.IsAny<long>())).Returns(() =>
            {
                var customer = new Customer(name, phone, address);
                return customer;
            });
            var repoObj = repo.Object;
            var controller = new CustomersController(repoObj);
            OkObjectResult result = (OkObjectResult)controller.Get(1);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.InstanceOf<CustomerDTO>());

            CustomerDTO dto = (CustomerDTO)result.Value;
            Assert.That(dto.Fullname, Is.EqualTo(name));

        }
        [Test]
        public async Task Return_204StatusCode_DeleteCustomers()
        {

            var repo = new Mock<IRepository<Customer>>();
            string name = "Deena K";
            string phone = "9997166369";
            string address = "Chennai";

            repo.Setup(m => m.GetById(It.IsAny<long>())).Returns(() => {
                var customer = new Customer(name, phone, address);
                return customer;

            });


            var repoObj = repo.Object;

            var controller = new CustomersController(repoObj);
            var result = (StatusCodeResult)await controller.DeleteCustomer(1).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(204));
        }


    }

}
   












