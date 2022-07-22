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
        public int customerId { get; set; }
        public string customerName { get; set; }

        public string phoneNumber { get; set; }
        public int totalAmount { get; set; }
        
        
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
