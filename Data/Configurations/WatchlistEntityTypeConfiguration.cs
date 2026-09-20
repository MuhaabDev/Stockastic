using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stockastic.Domain.Entities;

namespace Stockastic.Data.Configurations;

public class WatchlistEntityTypeConfiguration : IEntityTypeConfiguration<Watchlist>
{
    public void Configure(EntityTypeBuilder<Watchlist> builder)
    {
        builder.HasKey(w => w.Id);

        builder
            .HasIndex(w => w.UserId)
            .IsUnique();

        builder
            .HasOne(w => w.User)
            .WithOne(u => u.Watchlist)
            .HasForeignKey<Watchlist>(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(w => w.Items)
            .WithOne(i => i.Watchlist)
            .HasForeignKey(i => i.WatchlistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}