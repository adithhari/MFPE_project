using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using OrderManagement.Domain.Specifications;

namespace OrderManagement.Domain.Aggregates.OrderAggregate
{
    public class SearchByIdAndIncludeProductSpecification : SpecificationBase<Orders>
    {
        private readonly long OrderId;
        public SearchByIdAndIncludeProductSpecification(long orderid)
        {
            this.OrderId = orderid;
            base.Includes.Add("Products");
        }

        public override Expression<Func<Orders, bool>> ToExpression()
        {
            return obj => obj.Id == OrderId;
        }
    }
}
