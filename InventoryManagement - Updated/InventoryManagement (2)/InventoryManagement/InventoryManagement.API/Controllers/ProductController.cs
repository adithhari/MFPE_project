using InventoryManagement.Domain.Aggregates.InventoryAggregates;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Infrastructure;
using InventoryManagement.API.DTOs;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Category> categoryRepository;

        public ProductController(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddCategory(ProductDTO dto)
        {
            var category = categoryRepository.GetById(dto.categoryId);
            var product = new Product(dto.Name, dto.Description, dto.AvailableQuantity, dto.Price, category);
            
            productRepository.Add(product);
            await productRepository.SaveAsync();
            return StatusCode(201);

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<MergeDTO>))]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllProduct()
        {
            var spec = new GetAllProductsIncludingCategorySpecification();
            var products = productRepository.GetBySpec(spec);
            var dtos = from product in products
                       select new MergeDTO
                       {
                           Id = product.Id,
                           Name = product.Name,
                           Description = product.Description,
                           Price = product.Price,
                           AvailableQuantity = product.AvailableQuantity,
                           categoryId = product.category.Id,
                           categoryName = product.category.CategoryName

                       };
            return Ok(dtos);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        public IActionResult GetProduct(long id)
        {
            var spec = new GetProductById(id);
            var product = productRepository.GetBySpec(spec).FirstOrDefault();

            var dto =  new MergeDTO()
                      {

                          Id = product.Id,
                          Name = product.Name,
                          Description = product.Description,
                          Price = product.Price,
                          AvailableQuantity = product.AvailableQuantity,
                          categoryId = product.category.Id,
                          categoryName = product.category.CategoryName
                      };
            return Ok(dto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = (typeof(ProductDTO)))]
        public async Task<IActionResult> UpdateCategory(long id, [FromBody] ProductDTO dto)
        {
            var product = productRepository.GetById(id);
            if (product == null)
                return NotFound();

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.AvailableQuantity = dto.AvailableQuantity;
            productRepository.Update(product);
            await productRepository.SaveAsync();
            return Ok(product);
        }

        [HttpPut("updateqty/{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = (typeof(ProductDTO)))]
        public async Task<IActionResult> UpdateQty(long id, [FromBody]int qty)
        {
            var product = productRepository.GetById(id);
            if (product == null)
                return NotFound();
            product.AvailableQuantity = product.AvailableQuantity - qty;
            productRepository.Update(product);
            await productRepository.SaveAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = productRepository.GetById(id);
            if (product == null)
                return NotFound();
            productRepository.Remove(product);
            await productRepository.SaveAsync();
            return StatusCode(204);
        }


    }
}
