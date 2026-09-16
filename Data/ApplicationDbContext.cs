using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stockastic.Domain.Entities;
namespace Stockastic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        
        //Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(u => u.Id);

                    entity.Property(u => u.Username)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(u => u.Email)
                        .IsRequired()
                        .HasMaxLength(255);

                    entity.Property(u => u.PasswordHash)
                        .IsRequired();

                    entity.HasIndex(u => u.Username)
                        .IsUnique();

                    entity.HasIndex(u => u.Email)
                        .IsUnique();

                    entity.HasOne(u => u.Portfolio)
                        .WithOne(p => p.User)
                        .HasForeignKey<Portfolio>(p => p.UserId)
                        .OnDelete(DeleteBehavior.Cascade);
                }
            );

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Symbol)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(s => s.Company)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Sector)
                    .HasMaxLength(50);

                entity.HasIndex(s => s.Symbol)
                    .IsUnique();
            });

            modelBuilder.Entity<Holding>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(h => h.AverageBuyPrice)
                    .HasPrecision(18, 4);

                entity.HasOne(h => h.Portfolio)
                    .WithMany(p => p.Holdings)
                    .HasForeignKey(h => h.PortfolioId);

                entity.HasOne(h => h.Stock)
                    .WithMany(s => s.Holdings)
                    .HasForeignKey(h => h.StockId);

                entity.HasIndex(h => new
                {
                    h.PortfolioId,
                    h.StockId
                }).IsUnique();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Price)
                    .HasPrecision(18, 4);

                entity.Property(t => t.Type)
                    .HasConversion<string>();

                entity.HasOne(t => t.User)
                    .WithMany(u => u.Transactions)
                    .HasForeignKey(t => t.UserId);

                entity.HasOne(t => t.Stock)
                    .WithMany(s => s.Transactions)
                    .HasForeignKey(t => t.StockId);
            });
        }
    }
}
