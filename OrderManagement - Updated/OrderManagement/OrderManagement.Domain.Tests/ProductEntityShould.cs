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
    public class ProductEntityShould
    {
        [Test]
        public void Create_NewProduct_ViaConstructor()
        {
            long productId = 1;
            string productname = "Phone";
            int mrp = 50000;
            int qty = 100;
            int amount = 50000;
            var product = new Product(productId, productname, mrp, qty, amount);
            Assert.That(product, Is.Not.Null);
            Assert.That(product, Is.InstanceOf<Product>());
            Assert.That(product.ProductId, Is.EqualTo(productId));
            Assert.That(product.ProductName, Is.EqualTo(productname));
            Assert.That(product.Mrp, Is.EqualTo(mrp));
            Assert.That(product.Qty, Is.EqualTo(qty));
            Assert.That(product.Amount, Is.EqualTo(amount));
        }
    }
}
