using Stockastic.Domain.Entities;
using Stockastic.Services;
using Stockastic.UI.Trading_Page;
namespace Stockastic.UI;
public class TradingMenu(WatchlistMenu watchlist , TradeMenu trade , HoldingsMenu holdings)
{
    public async Task Show(User currentUser)
    {
        bool inTradingMenu = true;
        while (inTradingMenu)
        {
            DisplayMenu();
            if (!int.TryParse(Console.ReadLine(), out int option))
                Console.WriteLine("Invlid Input");
            switch (option)
            {
                case 1:
                    await trade.Show(currentUser);
                    break;

                case 2:
                    await holdings.Show(currentUser);
                    break;

                case 3:
                    await watchlist.Show(currentUser);
                    break;
                case 4:
                    inTradingMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("1. Trade ");
        Console.WriteLine("2. Holdings ");
        Console.WriteLine("3. Watchlist");
        Console.WriteLine("4. Exit ");
        Console.Write("Choose : ");
    }
}