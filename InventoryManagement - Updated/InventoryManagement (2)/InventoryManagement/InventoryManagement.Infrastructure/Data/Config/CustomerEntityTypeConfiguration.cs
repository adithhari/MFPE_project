using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Infrastructure.Data.Config
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Fullname).HasMaxLength(30).IsRequired(true);

            builder.Property(p => p.PhoneNumber).HasMaxLength(10).IsFixedLength(true).IsRequired(true);
            builder.Property(p => p.Address).HasMaxLength(50).IsRequired(true);
        }
    }
}
