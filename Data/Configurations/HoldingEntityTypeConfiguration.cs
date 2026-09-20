using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Data.Configurations;

public class HoldingEntityTypeConfiguration : IEntityTypeConfiguration<Holding>
{
    public void Configure(EntityTypeBuilder<Holding> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.AverageBuyPrice)
            .HasPrecision(18, 4);

        builder.HasOne(h => h.Portfolio)
            .WithMany(p => p.Holdings)
            .HasForeignKey(h => h.PortfolioId);

        builder.HasOne(h => h.Stock)
            .WithMany(s => s.Holdings)
            .HasForeignKey(h => h.StockId);

        builder.HasIndex(h => new
        {
            h.PortfolioId,
            h.StockId
        }).IsUnique();
    }
}
