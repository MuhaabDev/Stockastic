using Stockastic.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Text;
namespace Stockastic.Services;
public class WalletService(ApplicationDbContext context)
{
    public async Task<decimal> GetBalance(int userId)
    {
        var portfolio = await context.Portfolios.SingleOrDefaultAsync(p => p.UserId == userId);
        if (portfolio is null)
            throw new Exception("User not found.");
        return portfolio.CashBalance;
    }

    public async Task AddMoney(int userId, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var portfolio = await context.Portfolios
                .SingleOrDefaultAsync(p => p.UserId == userId);

        if (portfolio is null)
            throw new Exception("Portfolio not found.");

        portfolio.CashBalance += amount;
        await context.SaveChangesAsync();
    }

    public async Task WithdrawMoney(int userId, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var portfolio = await context.Portfolios
            .SingleOrDefaultAsync(p => p.UserId == userId);

        if (portfolio is null)
            throw new Exception("Portfolio not found.");
        if (portfolio.CashBalance < amount)
            throw new InvalidOperationException("Insufficient balance.");

        portfolio.CashBalance -= amount;
        await context.SaveChangesAsync();
    }
}