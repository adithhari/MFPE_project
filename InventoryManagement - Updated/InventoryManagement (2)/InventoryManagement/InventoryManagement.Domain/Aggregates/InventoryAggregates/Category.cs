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

        //public virtual IList<Product> Products { get; set; } = new List<Product>();



        public Category(string categoryName, string categoryDescription)
        {
            this.CategoryName = categoryName;
            this.CategoryDescription = categoryDescription;
        }
        private Category() { }


        //public void AddProduct(Product newProduct)
        //{
        //    this.Products.Add(newProduct);
        //}
        //public void RemoveProduct(long productId)
        //{
        //    var product = Products.First(p => p.Id == productId);
        //    this.Products.Remove(product);
        //}
    }

}
