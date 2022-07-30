using InventoryManagement.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Aggregates.InventoryAggregates
{
    public class Product : EntityBase 
    {
        public virtual string Name { get;  set; }
        
        public virtual string Description { get; set; }
        public virtual int Price { get;  set; }
        public virtual int AvailableQuantity { get;  set; }
        public virtual Category category { get; set; }
        

        public Product(string name, string description, int availableQuantity, int price, Category category )
        {

            this.category = category;

            this.Name = name;
            
            this.Description = description;
            
            this.AvailableQuantity = availableQuantity;

            this.Price = price;
           
        }
        private Product() { }



    }
}
