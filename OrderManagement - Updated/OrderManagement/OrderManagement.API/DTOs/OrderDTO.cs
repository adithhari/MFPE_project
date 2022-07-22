using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.API.DTOs
{
    public class OrderDTO
    {
        public long Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int TotalAmount { get; set; }
        
        
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
