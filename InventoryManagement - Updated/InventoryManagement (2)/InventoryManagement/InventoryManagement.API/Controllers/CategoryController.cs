using InventoryManagement.Domain.Aggregates.InventoryAggregates;
using InventoryManagement.Domain.Interfaces;
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

    public class CategoryController : Controller

    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddCategory(CategoryDTO dto)
        {
            var category = new Category(dto.CategoryName, dto.CatgoryDescription);
            categoryRepository.Add(category);
            await categoryRepository.SaveAsync();
            return StatusCode(201);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CategoryDTO>))]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetCategory()
        {
            var categories = categoryRepository.Get();
            var dtos = from category in categories
                       select new CategoryDTO
                       {
                           Id = category.Id,
                           CategoryName = category.CategoryName,
                           CatgoryDescription = category.CategoryDescription,
                       };
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CategoryDTO))]
        public IActionResult GetCategoryById(long id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = (typeof(CategoryDTO)))]
        public async Task<IActionResult> UpdateCategory(long id, [FromBody] CategoryDTO dto)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
                return NotFound();

            category.CategoryName = dto.CategoryName;
            category.CategoryDescription = dto.CatgoryDescription;
            categoryRepository.Update(category);
            await categoryRepository.SaveAsync();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
                return NotFound();
            categoryRepository.Remove(category);
            await categoryRepository.SaveAsync();
            return StatusCode(204);

        }


    }
}
