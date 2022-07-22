using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Aggregates;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Domain.Specifications;
using InventoryManagement.Infrastructure.Data.Contexts;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InventoryManagementContext context;

        public Repository(InventoryManagementContext context)
        {
            this.context = context;
        }

        public T Add(T item)
        {
            return context.Add(item).Entity;
        }

        public IReadOnlyCollection<T> Get()
        {
            var Data = context.Set<T>().ToList();
            return Data.AsReadOnly();
        }

        public T GetById(long id)
        {
            return context.Set<T>().Find(id);
        }

        public IReadOnlyCollection<T> GetBySpec(SpecificationBase<T> spec)
        {
            IQueryable<T> Set = context.Set<T>();
            foreach (var include in spec.Includes)
                Set = Set.Include(include);
            var Query = Set.Where(spec.ToExpression().Compile());
            return Query.ToList().AsReadOnly();
        }

        public T Remove(T item)
        {
            return context.Remove(item).Entity;
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public T Update(T item)
        {
            return context.Update(item).Entity;
        }
    }
}
