namespace Stockastic.Domain.Entities;
public class WatchlistItem
{
    public int Id { get; set; }
    public int WatchlistId { get; set; }
    public int StockId { get; set; }
    
    // Navigation
    public Watchlist Watchlist { get; set; } = null!;
    public Stock Stock { get; set; } = null!;
}