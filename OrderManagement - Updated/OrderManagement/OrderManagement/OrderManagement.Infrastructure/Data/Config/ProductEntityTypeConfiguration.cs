using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using OrderManagement.Domain.Aggregates.OrderAggregate;

namespace OrderManagement.Infrastructure.Data.Config
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            
            
            builder.Property(p => p.ProductId).IsRequired(true);
            builder.Property(p => p.ProductName).IsRequired(true);
            builder.Property(p => p.Mrp).IsRequired(true);
            builder.Property(p => p.Qty).IsRequired(true);
            builder.Property(p => p.Amount).IsRequired(true);


        }
    }
}
