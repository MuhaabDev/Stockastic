using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Stockastic.Data.Configurations;

public class StockEntityTypeConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure( EntityTypeBuilder<Stock> builder)
    {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Symbol)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(s => s.Company)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Sector)
                .HasMaxLength(50);

            builder.HasIndex(s => s.Symbol)
                .IsUnique();
    }
}