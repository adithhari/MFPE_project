
using InventoryManagement.API.DTOs;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;
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
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomersController(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddCustomer(CustomerDTO dto)
        {
            var customer = new Customer(dto.Fullname, dto.PhoneNumber, dto.Address);
            customerRepository.Add(customer);
            await customerRepository.SaveAsync();
            return StatusCode(201);
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CustomerDTO>))]

        public IActionResult GetCustomers()
        {
            var customers = customerRepository.Get();
            var dtos = from customer in customers
                       select new CustomerDTO
                       {
                           Id = customer.Id,
                           Fullname = customer.Fullname,
                           PhoneNumber = customer.PhoneNumber,
                           Address = customer.Address

                       };
            return Ok(dtos);
        }
        [HttpGet("{customerId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CustomerDTO))]

        public IActionResult Get(long customerId)
        {

            var customers = customerRepository.GetById(customerId);

            if (customers == null)
                return NotFound();

            var customerDto = new CustomerDTO()
            {
                Id = customers.Id,
                Fullname = customers.Fullname,
                PhoneNumber = customers.PhoneNumber,
                Address = customers.Address
            };


            return Ok(customerDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = (typeof(CustomerDTO)))]

        public async Task<IActionResult> UpdateCustomer(long id, [FromBody] CustomerDTO obj)
        {
            var customer = customerRepository.GetById(id);
            if (customer == null)
                return NotFound();
            //customer.UpdateCustomer(obj.PhoneNumber,obj.Fullname,obj.Address);
            //customerRepository.Update(customer);
            customer.Fullname = obj.Fullname;
            customer.PhoneNumber = obj.PhoneNumber;
            customer.Address = obj.Address;

            customerRepository.Update(customer);

            await customerRepository.SaveAsync();

            //var dto = CustomerDTOConverter.ToCustomerDTO(customer);
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]

        public async Task<IActionResult> DeleteCustomer(long id)
        {

            var customers = customerRepository.GetById(id);
            if (customers == null)
                return NotFound();
            customerRepository.Remove(customers);
            await customerRepository.SaveAsync();
            return StatusCode(204);
        }

    }
}
