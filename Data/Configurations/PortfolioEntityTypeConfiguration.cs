using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stockastic.Domain.Entities;

namespace Stockastic.Data.Configurations
{
    public class PortfolioEntityTypeConfiguration:IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(p => p.id);

            builder.Property(p => p.CashBalance)
                .HasPrecision(18, 2);
        }

    }
}