using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.API.DTOs
{
    public class CategoryDTO
    {
        public long Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]       
        public string CatgoryDescription { get; set; }
        
        

        
    }
}
