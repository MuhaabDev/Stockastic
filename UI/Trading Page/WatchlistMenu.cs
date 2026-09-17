using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Stockastic.Services.Trading_Service;
namespace Stockastic.UI.Trading_Page;
public class WatchlistMenu(WatchlistService watchlistService)
{
    public async Task Show(User currentUser)
    {
        bool inWatchlist = true;
        while (inWatchlist)
        {
            DisplayMenu();
            if (!int.TryParse(Console.ReadLine(), out int option))
                Console.WriteLine("Invlid Input");
            switch (option)
            {
                case 1:
                    await watchlistService.ViewWatchList(currentUser);
                    break;

                case 2:
                    await watchlistService.AddStockWatchList(currentUser);
                    break;

                case 3:
                    await watchlistService.RemoveStockWatchList(currentUser);
                    break;
                case 4:
                    inWatchlist = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
            
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("1. View WatchList");
        Console.WriteLine("2. Add Stock To Watchlist");
        Console.WriteLine("3. Remove Stock From Watchlist");
        Console.WriteLine("4. Exit Watchlist");
        Console.Write("Choose : ");
    }
}