using Microsoft.EntityFrameworkCore;
using Stockastic.Data;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Trading_Service;
public class StockService(ApplicationDbContext dbContext)
{
    public async Task<bool> StockExist(string symbol)
    {
        symbol = symbol.ToUpper();
        return await dbContext.Stocks.AnyAsync(s => s.Symbol == symbol);
    }

    public async Task<Stock?> GetStock(string symbol)
    {
        symbol = symbol.ToUpper();
        return await dbContext.Stocks.SingleOrDefaultAsync(s => s.Symbol == symbol);
    }
}