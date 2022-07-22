using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderManagement.Domain.Aggregates.OrderAggregate;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Aggregates.OrderAggregate
{
    public class Orders : EntityBase, IAggregateRoot

    { 
        public virtual int CustomerId { get; private set; }
        public virtual string CustomerName { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual int TotalAmount { get; private set; }




        public virtual IList<Product> Products { get; set; } = new List<Product>();
        public Orders(int customerId,string customerName, string phoneNumber,int totalAmount)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.PhoneNumber = phoneNumber;
            this.TotalAmount = totalAmount;
        }
        private Orders() { }
        public void AddProduct(Product newProduct)
        {
            this.Products.Add(newProduct);
        }
        public void RemoveProduct(long productId)
        {
            var product = Products.First(s => s.Id == productId);
            this.Products.Remove(product);
        }



    }
    
}
