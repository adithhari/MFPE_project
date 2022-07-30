using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using OrderManagement.Domain;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Aggregates;
using OrderManagement.Domain.Aggregates.OrderAggregate;

namespace OrderManagement.Domain.Tests
{
    [TestFixture]
    class OrderEntityShould
    {
        [Test]
        public void Create_NewOrder_ViaConstructor()
        {
            int customerId = 1;
            string customerName = "monisha";
            string phoneNumber = "1234567890";
            int totalAmount = 100;
            var orders = new Orders(customerId, customerName, phoneNumber, totalAmount);
            Assert.That(orders, Is.Not.Null);
            Assert.That(orders, Is.InstanceOf<Orders>());
            Assert.That(orders.CustomerId, Is.EqualTo(customerId));
            Assert.That(orders.CustomerName, Is.EqualTo(customerName));
            Assert.That(orders.PhoneNumber, Is.EqualTo(phoneNumber));
            Assert.That(orders.TotalAmount, Is.EqualTo(totalAmount));
        }
    }
}

