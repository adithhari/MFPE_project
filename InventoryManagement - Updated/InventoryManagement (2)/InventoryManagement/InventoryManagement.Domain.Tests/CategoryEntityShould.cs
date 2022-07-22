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
    public class CategoryEntityShould
    {
        [Test]
        public void Create_NewCategory_ViaConstructor()
        {
            //Arrange
            string CategoryName = "Electronics";
            string CategoryDescription = "Laptop";

            //Act
            var category = new Category(CategoryName, CategoryDescription);

            //Assert
            Assert.That(category, Is.Not.Null);
            Assert.That(category, Is.InstanceOf<Category>());
            Assert.That(category.CategoryName, Is.EqualTo(CategoryName));
            Assert.That(category.CategoryDescription, Is.EqualTo(CategoryDescription));
        }

    }
}
