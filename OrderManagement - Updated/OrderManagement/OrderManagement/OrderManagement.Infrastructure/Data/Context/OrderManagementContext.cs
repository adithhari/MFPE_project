using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Infrastructure.Data.Context
{
    public class OrderManagementContext :DbContext
    {
        public OrderManagementContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Orders> Order { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderManagementContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}





    


