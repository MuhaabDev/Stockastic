using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stockastic.Domain.Entities;

namespace Stockastic.Data;

public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Price)
            .HasPrecision(18, 4);

        builder.Property(t => t.Type)
            .HasConversion<string>();

        builder.HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId);

        builder.HasOne(t => t.Stock)
            .WithMany(s => s.Transactions)
            .HasForeignKey(t => t.StockId);
    }
}