using Stockastic.Data;
using Stockastic.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Trading;

public class TradingService(ApplicationDbContext context)
{
    public async Task Buy(User currentUser, string? symbol, int quantity)
    {
        throw new NotImplementedException();
    }
}
