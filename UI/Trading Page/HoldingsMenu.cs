using Stockastic.Domain.Entities;
using Stockastic.Services.Trading_Service;

namespace Stockastic.UI.Trading_Page;

public class HoldingsMenu( PortfolioService portfolioService , StockService stockService)
{
    public async Task Show(User currentUser)
    {
        while (true)
        {
            DisplayMenu();
            int option = MenuInput.ReadOption(1, 3);

            switch (option)
            {
                case 1:
                    await ViewHoldings(currentUser);
                    break;

                case 2:
                    await ViewHolding(currentUser);
                    break;

                case 3:
                    return;
            }
        }
    }

    private async Task ViewHoldings(User currentUser)
    {
        List<Holding> holdings = await portfolioService.GetHoldings(currentUser.Portfolio.id);

        if (holdings.Count == 0)
        {
            Console.WriteLine("You don't own any stocks.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("===== Holdings =====");

        Console.WriteLine(
            $"{"Stock",-10}" +
            $"{"Quantity",-12}" +
            $"{"Avg Price",-15}" +
            $"{"Current Price",-15}" +
            $"{"Value",-15}");

        foreach (Holding holding in holdings)
        {
            decimal currentPrice =  holding.Stock.price;
            decimal value = holding.Quantity * currentPrice;
            Console.WriteLine(
                $"{holding.Stock.Symbol,-10}" +
                $"{holding.Quantity,-12}" +
                $"{holding.AverageBuyPrice,-15:F2}" +
                $"{currentPrice,-15:F2}" +
                $"{value,-15:F2}");
        }
    }

    private async Task ViewHolding(User currentUser)
    {
        Console.Write("Enter Stock Symbol: ");
        string? symbol = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(symbol))
        {
            Console.WriteLine("Invalid symbol.");
            return;
        }

        Stock? stock = await stockService.GetStock(symbol);
        Holding? holding = await portfolioService.GetHolding( currentUser.Portfolio.id, stock.Id);

        if (holding == null)
        {
            Console.WriteLine(
                $"You don't own {symbol.ToUpper()}.");
            return;
        }

        decimal currentValue = holding.Quantity * holding.Stock.price;
        decimal invested = holding.Quantity * holding.AverageBuyPrice;
        decimal profitLoss = currentValue - invested;

        Console.WriteLine();
        Console.WriteLine($"Stock: {holding.Stock.Symbol}");
        Console.WriteLine($"Quantity: {holding.Quantity}");
        Console.WriteLine($"Average Price: {holding.AverageBuyPrice:F2}");
        Console.WriteLine($"Current Price: {holding.Stock.price:F2}");
        Console.WriteLine($"Current Value: {currentValue:F2}");
        Console.WriteLine($"Profit/Loss: {profitLoss:F2}");
    }

    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Holdings =====");
        Console.WriteLine("1. View Holdings");
        Console.WriteLine("2. View Holding Details");
        Console.WriteLine("3. Back");
    }
}