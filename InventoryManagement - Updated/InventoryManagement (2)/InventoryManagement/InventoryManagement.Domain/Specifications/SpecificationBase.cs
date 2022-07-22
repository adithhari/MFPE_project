using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using InventoryManagement.Domain.Aggregates;
using InventoryManagement.Domain.Entities;
using System.Linq;

namespace InventoryManagement.Domain.Specifications
{
    public abstract class SpecificationBase<T> where T : class
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public List<string> Includes { get; } = new List<string>();

        
    }
}
