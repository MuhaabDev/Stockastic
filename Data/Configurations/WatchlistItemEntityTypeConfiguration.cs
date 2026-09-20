using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stockastic.Domain.Entities;

namespace Stockastic.Data.Configurations;

public class WatchlistItemEntityTypeConfiguration : IEntityTypeConfiguration<WatchlistItem>
{
    public void Configure(EntityTypeBuilder<WatchlistItem> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .HasIndex(i => new
            {
                i.WatchlistId,
                i.StockId
            })
            .IsUnique();

        builder
            .HasOne(i => i.Watchlist)
            .WithMany(w => w.Items)
            .HasForeignKey(i => i.WatchlistId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(i => i.Stock)
            .WithMany()
            .HasForeignKey(i => i.StockId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}