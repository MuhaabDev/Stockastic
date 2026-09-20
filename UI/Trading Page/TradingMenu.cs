using Stockastic.Domain.Entities;
using Stockastic.Services;
using Stockastic.UI.Trading_Page;
namespace Stockastic.UI;
public class TradingMenu(WatchlistMenu watchlistMenu , TradeMenu tradeMenu , HoldingsMenu holdingsMenu)
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
                    await tradeMenu.Show(currentUser);
                    break;

                case 2:
                    await holdingsMenu.Show(currentUser);
                    break;

                case 3:
                    await watchlistMenu.Show(currentUser);
                    break;
                case 4:
                    return;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Trading =====");
        Console.WriteLine("1. Trade");
        Console.WriteLine("2. Holdings");
        Console.WriteLine("3. Watchlist");
        Console.WriteLine("4. Back");
    }
}