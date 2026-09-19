using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Trading_Service;

public class WatchlistService
{
    public Task ViewWatchList(object user)
    {
        throw new NotImplementedException();
    }
    public async Task AddStockWatchList(User user)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveStockWatchList(User currentUser)
    {
        throw new NotImplementedException();
    }

    internal async Task<bool> AddStock(int id1, int id2)
    {
        throw new NotImplementedException();
    }

    internal async Task<bool> RemoveStock(int id, string symbol)
    {
        throw new NotImplementedException();
    }

    internal async Task<List<Stock>> GetWatchlist(int id)
    {
        throw new NotImplementedException();
    }
}