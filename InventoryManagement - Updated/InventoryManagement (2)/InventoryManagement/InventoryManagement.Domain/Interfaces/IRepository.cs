using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.Domain.Aggregates;
using InventoryManagement.Domain.Entities;
using System.Threading.Tasks;
using InventoryManagement.Domain.Specifications;

namespace InventoryManagement.Domain.Interfaces
{
    public interface IRepository<T> where T: class
    {
        T Add(T item);
        T Remove(T item);
        T Update(T item);
        IReadOnlyCollection<T> Get();
        T GetById(long id);
        IReadOnlyCollection<T> GetBySpec(SpecificationBase<T> spec);
        Task<int> SaveAsync();


    }
}
