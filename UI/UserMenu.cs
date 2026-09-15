using Stockastic.Data;
using Stockastic.Domain.Entities;
using Stockastic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.UI;
public class UserMenu(AccountService accountService , PortfolioService portfolioService , TradingService tradingService)
{
    public void Show(User currentUser)
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
                    DisplayBalance(currentUser);
                    break;

                case 2:
                    AddMoney(currentUser);
                    break;

                case 3:
                    Trading(currentUser);
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

    private void DisplayBalance(User user)
    {
        var balance = accountService.GetBalance(user.Id);
        Console.WriteLine($"Balance: {balance}");
    }


    private void AddMoney(User user)
    {
        // read amount
        // call accountService.AddMoney(...)
    }

    private void Trading(User user)
    {
        // tradingService...
    }

    private void DisplaySettings(User user)
    {
        // settings...
    }
}
