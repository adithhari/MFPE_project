using InventoryManagement.Domain.Aggregates.InventoryAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Data.Config
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired(true);
           
            builder.Property(p => p.Description).IsRequired(true);
            builder.Property(p => p.Price).IsRequired(true);
            builder.Property(p => p.AvailableQuantity).IsRequired(true);

        }
    }
}
