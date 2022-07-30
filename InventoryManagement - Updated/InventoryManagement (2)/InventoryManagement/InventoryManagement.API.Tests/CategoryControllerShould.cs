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

        [Test]
        public void Return_200StatusCode()
        {
            var repo = new Mock<IRepository<Category>>();
            string CategoryName = "Electronics";
            string CatgoryDescription = "Laptop";

            repo.Setup(m => m.Get()).Returns(() =>
            {
                var category = new Category(CategoryName, CatgoryDescription);
                return new List<Category>() { category };
               
            });

            var repoObj = repo.Object;
            var controller = new CategoryController(repoObj);
            OkObjectResult result = (OkObjectResult)controller.GetCategory();
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Return_200StatusCode_WithDTO_ForValid_CategoryID()
        {
            var repo = new Mock<IRepository<Category>>();
            string CategoryName = "Electronics";
            string CatgoryDescription = "Laptop";

            repo.Setup(m => m.GetById(It.IsAny<long>())).Returns(() =>
            {
                var category = new Category(CategoryName, CatgoryDescription);
                return category;
            });

            var repoObj = repo.Object;
            var controller = new CategoryController(repoObj);

            OkObjectResult result = (OkObjectResult)controller.GetCategoryById(1);

            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.InstanceOf<CategoryDTO>());

            CategoryDTO dto = (CategoryDTO)result.Value;
            Assert.That(dto.CategoryName, Is.EqualTo(CategoryName));
        }

        [Test]
        public async Task Return_204StatusCode()
        {
            var repo = new Mock<IRepository<Category>>();
            string CategoryName = "Electronics";
            string CatgoryDescription = "Laptop";

            repo.Setup(m => m.GetById(It.IsAny<long>())).Returns(() =>
            {
                var category = new Category(CategoryName, CatgoryDescription);
                return category;
            });

            var repoObj = repo.Object;
            var controller = new CategoryController(repoObj);

            var result = (StatusCodeResult)await controller.DeleteCategory(1).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(204));
        }
    }
}

