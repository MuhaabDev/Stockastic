using Microsoft.EntityFrameworkCore;
using Stockastic.Data;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Trading_Service;

public class WatchlistService(ApplicationDbContext context)
{
    public async Task<Watchlist?> GetWatchList(User currentUser)
    {
        return await context.Watchlists
            .Include(w => w.Items)
            .ThenInclude(i => i.Stock)
            .SingleOrDefaultAsync(w => w.UserId == currentUser.Id);
    }
    public async Task<bool> AddStockWatchList(User currentUser , Stock stock)
    {
        Watchlist? watchlist = await GetWatchList(currentUser);
        if (watchlist == null) 
            throw new InvalidOperationException("User does not have a watchlist.");

        bool alreadyExists = watchlist.Items.Any(i => i.StockId == stock.Id);
        if (alreadyExists) 
            return false;

        WatchlistItem item = new WatchlistItem { WatchlistId = watchlist.Id, StockId = stock.Id };
        watchlist.Items.Add(item);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveStockWatchList(User currentUser , Stock stock)
    {
        Watchlist? watchlist = await GetWatchList(currentUser);

        if (watchlist == null)
            throw new InvalidOperationException("User does not have a watchlist.");

        WatchlistItem? item = watchlist.Items.SingleOrDefault(i => i.StockId == stock.Id);

        if (item == null)
            return false;

        watchlist.Items.Remove(item);
        await context.SaveChangesAsync();
        return true;
    }
}