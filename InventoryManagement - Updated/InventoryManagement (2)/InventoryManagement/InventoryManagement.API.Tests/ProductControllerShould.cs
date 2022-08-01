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
    public class ProductControllerShould
    {
        [Test]
        public async Task Return_201StatusCode()
        {
            var dto = new ProductDTO()
            {
                Name = "Laptop",
                Description = "Hp",
                Price = 3000,
                AvailableQuantity = 10,
                categoryId = 1

            };


            var repo = new Mock<IRepository<Product>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var repoObj = repo.Object;

            var repos = new Mock<IRepository<Category>>();
            repos.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var reposObj = repos.Object;

            var controller = new ProductController(repoObj, reposObj);

            var result = (StatusCodeResult)await controller.AddProduct(dto).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(201));
        }

        [Test]
        public void Return_200StatusCode_Product()
        {

            var repo = new Mock<IRepository<Product>>();
            var repos = new Mock<IRepository<Category>>();

            string name = "Phone";
            string description = "Electronics Item To Make Life Easier";
            int price = 20000;
            int availableQuantity = 25;

            Category category = new Category();


            repo.Setup(m => m.GetBySpec(It.IsAny<GetAllProductsIncludingCategorySpecification>())).Returns(() =>
            {
                var product = new Product(name, description, price, availableQuantity, category);
                return new List<Product>() { product };
            });

            var repoObj = repo.Object;
            var reposObj = repos.Object;


            var controller = new ProductController(repoObj, reposObj);
            OkObjectResult result = (OkObjectResult)controller.GetAllProduct();

            Assert.That(result.StatusCode, Is.EqualTo(200));


        }


        [Test]
        public void Return_200StatusCode_WithDTO_ForValid_ProductID()
        {
            var repo = new Mock<IRepository<Product>>();
            var repos = new Mock<IRepository<Category>>();

            string name = "Laptop";
            string description = "Hp";
            int price = 3000;
            int availableQuantity = 10;
            Category category = new Category();



            repo.Setup(m => m.GetBySpec(It.IsAny<GetProductById>())).Returns(() =>
            {
                var product = new Product(name, description, price, availableQuantity, category);
                return new List<Product>() { product };
            });




            var repoObj = repo.Object;
            var reposObj = repos.Object;
            var controller = new ProductController(repoObj, reposObj);
            OkObjectResult result = (OkObjectResult)controller.GetProduct(1);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.InstanceOf<MergeDTO>());

            MergeDTO dto = (MergeDTO)result.Value;
            Assert.That(dto.Name, Is.EqualTo(name));
        }

        [Test]
        public async Task Return_204_StatusCode_DeleteProduct()
        {
            var repo = new Mock<IRepository<Product>>();
            var repos = new Mock<IRepository<Category>>();
            string name = "CocaCola";
            string description = "it is a soft drink";
            int price = 50;
            int availableQuantity = 100;
            Category category = new Category();

            repo.Setup(m => m.GetById(It.IsAny<long>())).Returns(() =>
            {
                var product = new Product(name, description, price, availableQuantity, category);
                return product;
            });

            var repoObj = repo.Object;
            var reposObj = repos.Object;
            var controller = new ProductController(repoObj, reposObj);

            var result = (StatusCodeResult)await controller.DeleteProduct(1).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(204));

        }

    }
}