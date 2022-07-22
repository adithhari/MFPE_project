using InventoryManagement.Domain.Specifications;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InventoryManagement.Domain.Aggregates.InventoryAggregates
{
   public class GetAllProductsIncludingCategorySpecification : SpecificationBase<Product>
    {

        public GetAllProductsIncludingCategorySpecification()
        {

            base.Includes.Add("category");
        }
        public override Expression<Func<Product, bool>> ToExpression()
        {
            return obj => true;
        }
    }
}
