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
    public class CategoryControllerShould
    {
        [Test]
        public async Task Return_201StatusCode()
        {
            var dto = new CategoryDTO()
            {
                CategoryName = "Electronics",
                CatgoryDescription = "Laptop"
            };

            var repo = new Mock<IRepository<Category>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var repoObj = repo.Object;

            var controller = new CategoryController(repoObj);

            var result = (StatusCodeResult)await controller.AddCategory(dto).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(201));
        }


    }
}

