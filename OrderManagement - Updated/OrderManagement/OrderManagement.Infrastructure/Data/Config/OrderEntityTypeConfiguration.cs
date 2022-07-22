using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

using OrderManagement.Domain.Aggregates.OrderAggregate;


namespace OrderManagement.Infrastructure.Data.Config
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Orders>
    {
     
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CustomerId).IsRequired(true);
            builder.Property(p => p.CustomerName).IsRequired(true);
            builder.Property(p => p.PhoneNumber).IsRequired(true);
            builder.Property(p => p.TotalAmount).IsRequired(true);

        }
    }
}

