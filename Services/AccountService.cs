using Stockastic.Data;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services;
public class AccountService(ApplicationDbContext context)
{
    public decimal GetBalance(int userId)
    {
        var user = context.Users.Find(userId);

        if (user is null)
            throw new Exception("User not found.");

        return 0;
    }

    public void AddMoney(int userId, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var user = context.Users.Find(userId);

        if (user is null)
            throw new Exception("User not found.");

        //user.Balance += amount;

        context.SaveChanges();
    }

    public void WithdrawMoney(int userId, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var user = context.Users.Find(userId);

        if (user is null)
            throw new Exception("User not found.");

        //if (user.Balance < amount)
        //    throw new InvalidOperationException("Insufficient balance.");

        //user.Balance -= amount;

        context.SaveChanges();
    }
}