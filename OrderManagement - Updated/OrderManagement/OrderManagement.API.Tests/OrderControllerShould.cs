using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using OrderManagement.API;
using OrderManagement.API.Controllers;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using Moq;
using OrderManagement.API.DTOs;
using OrderManagement.Domain.Aggregates.OrderAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OrderManagement.API.Tests
{
    [TestFixture]
    public class OrderControllerShould
    {

        [Test]
        public void Return_200StatusCode_ShouldReturnAllOrders()
        {
            var repo = new Mock<IRepository<Orders>>();


            int customerId = 1;
            string customerName = "monisha";
            string phoneNumber = "1234567890";
            int totalAmount = 100;

            repo.Setup(m => m.Get()).Returns(() =>
            {

                var orders = new Orders(customerId, customerName, phoneNumber, totalAmount);
                return new List<Orders>() { orders };
            });
            var repoObj = repo.Object;
            var controller = new OrderController(repoObj);
            OkObjectResult result = (OkObjectResult)controller.GetOrders();
            Assert.That(result.StatusCode, Is.EqualTo(200));


        }
        [Test]
        public async Task Return_201_StatusCode()
        {

            var dto = new OrderDTO()
            {
                CustomerId = 25,
                CustomerName = "Trump",
                PhoneNumber = "1918171615",
                TotalAmount = 15000
            };

            var dtos = new ProductDTO()
            {
                ProductId = 45,
                ProductName = "Shoe",
                Mrp = 500,
                Qty = 30,
                Amount = 15000
            };

            var repo = new Mock<IRepository<Orders>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var repoObj = repo.Object;

            var controller = new OrderController(repoObj);

            var result = (StatusCodeResult)await controller.AddOrder(dto).ConfigureAwait(false);

            Assert.That(result.StatusCode, Is.EqualTo(201));
        }



    }
}
