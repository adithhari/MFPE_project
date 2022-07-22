using InventoryManagement.Domain.Specifications;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InventoryManagement.Domain.Aggregates.InventoryAggregates
{
    public class GetProductById : SpecificationBase<Product>
    {
        public long productId;

        public GetProductById(long productid)
        {
            this.productId = productid;
            base.Includes.Add("category");
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return obj => obj.Id == productId;
        }
    }
}
