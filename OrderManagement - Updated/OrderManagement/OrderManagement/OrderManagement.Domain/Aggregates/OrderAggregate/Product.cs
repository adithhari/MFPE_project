using System;
using System.Collections.Generic;
using System.Text;
using OrderManagement.Domain.Entities;


namespace OrderManagement.Domain.Aggregates.OrderAggregate
{
    public class Product : EntityBase
    {
        public virtual long ProductId { get; private set; }
        public virtual string ProductName { get; private set; }
        public virtual int Mrp { get; private set; }
        public virtual int Qty { get; private set; }
        public virtual int Amount { get; private set; }

        public Product(long productId,string productname, int mrp, int qty, int amount)
        {
            this.ProductId = productId;
            this.ProductName = productname;
            this.Mrp = mrp;
            this.Qty = qty;
            this.Amount = amount;



        }
        protected Product() { }

    }
}















