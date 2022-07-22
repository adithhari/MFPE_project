using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Domain.Aggregates.InventoryAggregates;
namespace InventoryManagement.API.DTOs
{
    public class MergeDTO
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }

        public  string  categoryName { get; set; }

        public long categoryId { get; set; }
    }
}
