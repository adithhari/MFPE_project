using System;
using System.Collections.Generic;
using System.Text;

using NUnit;
using NUnit.Framework;
using InventoryManagement.Domain;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Aggregates.InventoryAggregates;
using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Domain.Tests
{
    [TestFixture]
    public class ProductEntityShould
    {
        [Test]
        public void Create_NewProduct_ViaConstructor()
        {
            //Arrange
            string Name = "Laptop";
            string Description = "Hp";
            int AvailableQuantity = 10;
            int Price = 3000;
            Category category = new Category();

            //Act
            var product = new Product(Name, Description, AvailableQuantity, Price, category);

            //Assert
            Assert.That(product, Is.Not.Null);
            Assert.That(product, Is.InstanceOf<Product>());
            Assert.That(product.Name, Is.EqualTo(Name));
            Assert.That(product.Description, Is.EqualTo(Description));
            Assert.That(product.AvailableQuantity, Is.EqualTo(AvailableQuantity));
            Assert.That(product.Price, Is.EqualTo(Price));
            Assert.That(product.category, Is.EqualTo(category));


        }
    }
}

