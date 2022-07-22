using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.API.DTOs
{
    public class MergeDTO
    {
        public long Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string PhoneNumber { get; set; }
        public int TotalAmount { get; set; }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        [Required]
        public int Mrp { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public int Amount { get; set; }

    }
}
