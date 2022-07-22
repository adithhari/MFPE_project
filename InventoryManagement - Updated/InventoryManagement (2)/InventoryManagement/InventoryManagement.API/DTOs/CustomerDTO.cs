using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.API.DTOs
{
    public class CustomerDTO
    {
        public long Id { get; set; }
        [Required, StringLength(30)]
        public string Fullname { get; set; }

        [Required, RegularExpression(@"^[\d]{10}$")]
        public string PhoneNumber { get; set; }

        [Required, StringLength(50)]
        public string Address { get; set; }
    }
}
