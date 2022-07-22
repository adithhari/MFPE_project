using InventoryManagement.Domain.Aggregates.InventoryAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Data.Config
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        

        public void Configure(EntityTypeBuilder<Category> builder)
        {
         
            builder.Property(p => p.CategoryName).IsRequired(true);
            builder.Property(p => p.CategoryDescription).IsRequired(true);
        }
    }
}
