using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Domain.Aggregates.OrderAggregate;

namespace OrderManagement.API.DTOs
{
    public class ProductDTO
    {
        public long Id { get; set; }
        [Required]

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        [Required]
        public int Mrp{ get; set; }
        [Required]
        public int Qty{ get; set; }
        [Required]
        public int Amount { get; set; }


    }
}
