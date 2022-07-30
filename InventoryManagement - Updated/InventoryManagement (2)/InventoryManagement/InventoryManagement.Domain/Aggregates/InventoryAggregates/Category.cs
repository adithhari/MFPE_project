using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.Domain.Entities;
using System.Linq;

namespace InventoryManagement.Domain.Aggregates.InventoryAggregates
{
    public class Category : EntityBase, IAggregateRoot
    {
        public virtual string CategoryName { get; set; }
        public virtual string CategoryDescription { get;  set; }


        public Category(string categoryName, string categoryDescription)
        {
            this.CategoryName = categoryName;
            this.CategoryDescription = categoryDescription;
        }
        private Category() { }

    }

}
