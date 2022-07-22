using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagement.API.DTOs;
using OrderManagement.Domain.Aggregates.OrderAggregate;
using OrderManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {

        private readonly IRepository<Orders> orderRepository;

        public OrderController(IRepository<Orders> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]

        public async Task<IActionResult> AddCustomer(OrderDTO dto)
        {
            var customer = new Orders(dto.CustomerId, dto.CustomerName, dto.PhoneNumber, dto.TotalAmount );
            Product product = null;
            foreach (var productDTO in dto.Products)
            {
                product = new Product(productDTO.ProductId, productDTO.ProductName, productDTO.Mrp, productDTO.Qty, productDTO.Amount);
                customer.AddProduct(product);

                var jsonData = JsonConvert.SerializeObject(productDTO.Qty);
                var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    var response = client.PutAsync("http://localhost:61614/api/Product/updateqty/" + productDTO.ProductId, encodedData);
                    var responseData = response.Result.Content.ReadAsStringAsync();
                    var b = JsonConvert.DeserializeObject(responseData.Result);
                }
            }

            orderRepository.Add(customer);
            await orderRepository.SaveAsync();
            return StatusCode(201);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<OrderDTO>))]

        public IActionResult GetOrders()
        {

            var customers = orderRepository.Get();
            var dtos = from customer in customers
                       select new OrderDTO
                       {
                           Id = customer.Id,
                           CustomerId = customer.CustomerId,
                           CustomerName = customer.CustomerName,
                           PhoneNumber = customer.PhoneNumber,
                           TotalAmount = customer.TotalAmount
                       };
            return Ok(dtos);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(OrderDTO))]

        public IActionResult Get(long Id)
        {
            var spec = new SearchByIdAndIncludeProductSpecification(Id);
            var customers = orderRepository.GetBySpec(spec);
            if (customers.Count == 0)
                return NotFound();

            var customer = customers.First();
            var orderDto = new OrderDTO()
            {
                Id = customer.Id,
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                TotalAmount = customer.TotalAmount,

            };
            ProductDTO productDto = null;
            foreach (var product in customer.Products)
            {
                productDto = new ProductDTO()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Mrp = product.Mrp,
                    Qty = product.Qty,
                    Amount = product.Amount
                };
                orderDto.Products.Add(productDto);
            }
            return Ok(orderDto);
        }






    }
}  



    

