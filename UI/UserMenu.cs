using Stockastic.Data;
using Stockastic.Domain.Entities;
using Stockastic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.UI;
public class UserMenu(AccountService accountService , PortfolioService portfolioService , TradingService tradingService)
{
    public async Task Show(User currentUser)
    {
        while (true) {
            DisplayMenu();
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }
            switch (option)
            {
                case 1:
                    await DisplayBalance(currentUser);
                    break;

                case 2:
                    await AddMoney(currentUser);
                    break;

                case 3:
                    await Trading(currentUser);
                    break;

                case 4:
                    DisplaySettings(currentUser);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Display Balance");
        Console.WriteLine("2. Add Money");
        Console.WriteLine("3. Trading");
        Console.WriteLine("4. Settings");
        Console.WriteLine("5. Logout");
        Console.Write("Choose: ");
    }

    private async Task DisplayBalance(User user)
    {
        var balance = accountService.GetBalance(user.Id);
        Console.WriteLine($"Balance: {balance}");
    }


    private async Task AddMoney(User user)
    {
        throw new NotImplementedException();
        // read amount
        // call accountService.AddMoney(...)
    }

    private async Task Trading(User user)
    {
        throw new NotImplementedException();
        // tradingService...
    }

    private void DisplaySettings(User user)
    {
        throw new NotImplementedException();
        // settings...
    }
}
