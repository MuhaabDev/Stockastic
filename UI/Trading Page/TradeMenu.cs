using Stockastic.Domain.Entities;
using Stockastic.Services.Trading;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.UI.Trading_Page;
public class TradeMenu(TradingService tradingService)
{
    public async Task Show(User currentUser)
    {
        bool inTrade = true;
        while (inTrade)
        {
            DisplayMenu();
            if (!int.TryParse(Console.ReadLine(), out int option))
                Console.WriteLine("Invlid Input");
            switch (option)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:
                    inTrade = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("1. Buy ");
        Console.WriteLine("2. Sell ");
        Console.WriteLine("3. Exit ");
        Console.Write("Choose : ");
    }
}
