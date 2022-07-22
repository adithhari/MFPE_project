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

    }

}

