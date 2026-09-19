namespace Stockastic.Services.Trading_Service;
using Microsoft.EntityFrameworkCore;
using Stockastic.Data;
using Stockastic.Domain.Entities;

public class PortfolioService(ApplicationDbContext dbContext)
{
    public async Task<Holding?> GetHolding(int portfolioId, int stockId)
    {
        return await dbContext.Holdings.SingleOrDefaultAsync(h =>
                h.PortfolioId == portfolioId &&
                h.StockId == stockId);
    }

    public async Task<List<Holding>> GetHoldings(int portfolioId)
    {
        return await dbContext.Holdings
            .Where(h => h.PortfolioId == portfolioId)
            .ToListAsync();
    }

    public async Task AddHolding(int portfolioId,int stockId,int quantity,decimal averagePrice)
    {
        Holding holding = new Holding
        {
            PortfolioId = portfolioId,
            StockId = stockId,
            Quantity = quantity,
            AverageBuyPrice = averagePrice
        };

        await dbContext.Holdings.AddAsync(holding);
        await dbContext.SaveChangesAsync();
    }

    public async Task IncreaseQuantity(Holding holding,int quantity,decimal purchasePrice)
    {
        int oldQuantity = holding.Quantity;
        decimal oldValue = oldQuantity * holding.AverageBuyPrice;
        decimal newValue = quantity * purchasePrice;
        holding.Quantity += quantity;
        holding.AverageBuyPrice = (oldValue + newValue) / holding.Quantity;
        await dbContext.SaveChangesAsync();
    }

    public async Task DecreaseQuantity( Holding holding, int quantity)
    {
        holding.Quantity -= quantity;
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveHolding(Holding holding)
    {
        dbContext.Holdings.Remove(holding);
        await dbContext.SaveChangesAsync();
    }
}