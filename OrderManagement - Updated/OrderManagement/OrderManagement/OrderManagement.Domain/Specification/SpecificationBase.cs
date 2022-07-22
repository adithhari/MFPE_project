using System;
using System.Collections.Generic;
using System.Text;
using OrderManagement.Domain.Aggregates;
using OrderManagement.Domain.Entities;
using System.Linq.Expressions;
using System.Linq;
namespace OrderManagement.Domain.Specifications
{
    public abstract class SpecificationBase<T> where T : class
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public List<string> Includes { get; } = new List<string>();
    }
}
