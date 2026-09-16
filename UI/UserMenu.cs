using Stockastic.Data;
using Stockastic.Domain.Entities;
using Stockastic.Services;
using Stockastic.Services.Trading;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.UI;
public class UserMenu(WalletService walletService , Settings settings)
{
    public async Task Show(User currentUser)
    {
        ApplyUserSettings(currentUser);
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
                    Console.Write("Enter Amount To Add : ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                        Console.WriteLine("Invalid Input");
                    await AddMoney(currentUser , amount);
                    break;

                case 3:
                    await Trading(currentUser);
                    break;

                case 4:
                    await DisplaySettings(currentUser);
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
        decimal balance = await walletService.GetBalance(user.Id);
        Console.WriteLine($"Balance: {balance}");
    }

    private async Task AddMoney(User user , decimal amount)
    {
        await walletService.AddMoney(user.Id, amount);
    }

    private async Task Trading(User user)
    {
        throw new NotImplementedException();
        // tradingService...
    }

    private async Task DisplaySettings(User user)
    {
        await settings.show(user);
    }

    private void ApplyUserSettings(User user)
    {
        Console.ForegroundColor = user.SelectedColor;
    }
}
