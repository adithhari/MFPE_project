using InventoryManagement.Domain.Aggregates.InventoryAggregates;
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Data.Contexts
{
    public class InventoryManagementContext : DbContext
    {
       public InventoryManagementContext(DbContextOptions options) : base(options)

        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryManagementContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }



    }
}
