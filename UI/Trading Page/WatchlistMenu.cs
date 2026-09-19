using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Stockastic.Services.Trading_Service;
namespace Stockastic.UI.Trading_Page;
public class WatchlistMenu(WatchlistService watchlistService, StockService stockService)
{
    public async Task Show(User currentUser)
    {
        while (true)
        {
            DisplayMenu();
            int option = MenuInput.ReadOption(1, 4);
            switch (option)
            {
                case 1:
                    await ViewWatchlist(currentUser);
                    break;

                case 2:
                    await AddStock(currentUser);
                    break;

                case 3:
                    await RemoveStock(currentUser);
                    break;

                case 4:
                    return;
            }
        }
    }

    private async Task ViewWatchlist(User currentUser)
    {
        List<Stock> stocks = await watchlistService.GetWatchlist(currentUser.Id);

        if (stocks.Count == 0)
        {
            Console.WriteLine("Watchlist is empty.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("===== Watchlist =====");

        foreach (Stock stock in stocks)
        {
            Console.WriteLine( $"{stock.Symbol,-8} {stock.price,10:F2}");
        }
    }

    private async Task AddStock(User currentUser)
    {
        Console.Write("Enter Stock Symbol: ");

        string? symbol = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(symbol))
        {
            Console.WriteLine("Invalid symbol.");
            return;
        }

        Stock? stock = await stockService.GetStock(symbol);

        if (stock == null)
        {
            Console.WriteLine("Stock doesn't exist.");
            return;
        }

        bool added =  await watchlistService.AddStock(currentUser.Id, stock.Id);

        if (added)
            Console.WriteLine("Stock added to watchlist.");
        else
            Console.WriteLine("Stock already exists in watchlist.");
    }

    private async Task RemoveStock(User currentUser)
    {
        Console.Write("Enter Stock Symbol: ");

        string? symbol = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(symbol))
        {
            Console.WriteLine("Invalid symbol.");
            return;
        }

        bool removed = await watchlistService.RemoveStock(currentUser.Id, symbol);

        if (removed)
            Console.WriteLine("Stock removed.");
        else
            Console.WriteLine("Stock isn't in your watchlist.");
    }

    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Watchlist =====");
        Console.WriteLine("1. View Watchlist");
        Console.WriteLine("2. Add Stock");
        Console.WriteLine("3. Remove Stock");
        Console.WriteLine("4. Back");
    }
}