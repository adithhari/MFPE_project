using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class Customer : EntityBase
    {
        public virtual string Fullname { get; set; }

        public virtual string PhoneNumber { get; set; }
        public virtual string Address { get; set; }
        public Customer(string fullName, string phoneNumber, string Address)
        {
            this.Fullname = fullName;
            this.PhoneNumber = phoneNumber;
            this.Address = Address;


        }
        protected Customer() { }
    }
}
