using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stockastic.Data.Configurations;
using Stockastic.Domain.Entities;
namespace Stockastic.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
    
    //Entities
    public DbSet<User> Users { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Holding> Holdings { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Watchlist> Watchlists { get; set; }
    public DbSet<WatchlistItem> WatchlistItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        new StockEntityTypeConfiguration().Configure(modelBuilder.Entity<Stock>());
        new HoldingEntityTypeConfiguration().Configure(modelBuilder.Entity<Holding>());
        new TransactionEntityTypeConfiguration().Configure(modelBuilder.Entity<Transaction>());
        new PortfolioEntityTypeConfiguration().Configure(modelBuilder.Entity<Portfolio>());
        new WatchlistEntityTypeConfiguration().Configure(modelBuilder.Entity<Watchlist>());
        new WatchlistItemEntityTypeConfiguration().Configure(modelBuilder.Entity<WatchlistItem>());
    }
}
