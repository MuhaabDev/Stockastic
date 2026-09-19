using Stockastic.Data;
using Stockastic.Domain.Entities;
using Stockastic.Services.Authentication;
using Stockastic.Services.Trading_Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Trading;

public class TradingService
{
    private readonly StockService stockService;
    private readonly PortfolioService portfolioService;
    private readonly WalletService walletService;
    private readonly ApplicationDbContext context;

    public TradingService(StockService stockService , WalletService walletService, ApplicationDbContext context , PortfolioService portfolioService)
    {
        this.stockService = stockService;
        this.walletService = walletService;
        this.context = context;
        this.portfolioService = portfolioService;
    }

    public async Task<bool> Buy(User currentUser, Stock stock , int Quantity)
    {
        if (Quantity <= 0)
            return false;

        await using var trasaction = await context.Database.BeginTransactionAsync();
        try
        {
            decimal total_amount = Quantity * stock.price;
            decimal user_balance = await walletService.GetBalance(currentUser.Id);
            if (total_amount > user_balance)
                return false;

            Holding? holding = await portfolioService.GetHolding(currentUser.Portfolio.id, stock.Id);
            if (holding == null)
                await portfolioService.AddHolding(currentUser.Portfolio.id, stock.Id, Quantity,stock.price);
            else
                await portfolioService.IncreaseQuantity(holding, Quantity, stock.price);

            await walletService.WithdrawMoney(currentUser.Id, total_amount);
            await trasaction.CommitAsync();
            return true;
        }
        catch
        {
            await trasaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> Sell(User currentUser, Stock stock, int Quantity) {
        if (Quantity <= 0)
            return false;

        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            Holding? holding = await portfolioService.GetHolding(currentUser.Portfolio.id, stock.Id);

            if (holding == null)
                return false;

            if (Quantity <= 0 || Quantity > holding.Quantity)
                return false;

            holding.Quantity -= Quantity;
            if (holding.Quantity == 0) 
                await portfolioService.RemoveHolding(holding);
            await walletService.AddMoney(currentUser.Id , Quantity * stock.price);
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync(); 
            throw;
        }
    }
}