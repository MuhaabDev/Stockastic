using Stockastic.Domain.Entities;
using Stockastic.Services.Trading;
using Stockastic.Services.Trading_Service;
namespace Stockastic.UI.Trading_Page;
public class TradeMenu(TradingService tradingService , StockService stockService , PortfolioService portfolioService)
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
                    await BuyStock(currentUser);
                    break;

                case 2:
                    await SellStock(currentUser);
                    break;

                case 3:
                    return;
            }
        }
    }

    private async Task SellStock(User currentUser)
    {
        List<Holding> holdings = await portfolioService.GetHoldings(currentUser.Portfolio.id);

        if (holdings.Count == 0)
        {
            Console.WriteLine("You don't have any stocks to sell.");
            return;
        }

        DisplayHoldings(holdings);
        Holding? holding = ReadHoldingToSell(holdings);
        if (holding == null)
            return;

        int? quantity = ReadSellQuantity(holding);
        if (quantity == null)
            return;

        ShowSellSummary(holding, quantity.Value);

        if (!MenuInput.ReadConfirmation("Confirm Sell:"))
        {
            Console.WriteLine("Sale cancelled.");
            return;
        }

        bool completed = await tradingService.Sell(currentUser,holding.Stock,quantity.Value);
        Console.WriteLine(completed  ? "Sale completed successfully.": "Sale couldn't be completed.");
    }

    private void DisplayHoldings(List<Holding> holdings)
    {
        Console.WriteLine();
        Console.WriteLine("===== Your Holdings =====");

        Console.WriteLine(
            $"{"Stock",-10}" +
            $"{"Quantity",-12}" +
            $"{"Price",-15}" +
            $"{"Total Value",-15}");

        foreach (Holding holding in holdings)
        {
            decimal price = holding.Stock.price;
            decimal totalValue = holding.Quantity * price;

            Console.WriteLine(
                $"{holding.Stock.Symbol,-10}" +
                $"{holding.Quantity,-12}" +
                $"{price,-15:F2}" +
                $"{totalValue,-15:F2}");
        }
    }
    private Holding? ReadHoldingToSell(List<Holding> holdings)
    {
        Console.Write("Enter Stock Symbol To Sell: ");

        string? symbol = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(symbol))
        {
            Console.WriteLine("Invalid stock symbol.");
            return null;
        }

        symbol = symbol.Trim().ToUpper();

        Holding? holding = holdings.FirstOrDefault(
            h => h.Stock.Symbol == symbol
        );

        if (holding == null)
        {
            Console.WriteLine($"You don't own {symbol}.");
            return null;
        }

        return holding;
    }
    private int? ReadSellQuantity(Holding holding)
    {
        Console.Write("Enter Quantity To Sell: ");

        if (!int.TryParse(Console.ReadLine(), out int quantity)
            || quantity <= 0)
        {
            Console.WriteLine("Invalid quantity.");
            return null;
        }

        if (quantity > holding.Quantity)
        {
            Console.WriteLine(
                $"You only own {holding.Quantity} shares.");
            return null;
        }

        return quantity;
    }
    private void ShowSellSummary(Holding holding, int quantity)
    {
        decimal price = holding.Stock.price;
        decimal total = quantity * price;

        Console.WriteLine();
        Console.WriteLine("===== Sale Summary =====");
        Console.WriteLine($"Stock: {holding.Stock.Symbol}");
        Console.WriteLine($"Quantity: {quantity}");
        Console.WriteLine($"Price: {price:F2}");
        Console.WriteLine($"Total: {total:F2}");
    }
    private async Task BuyStock(User currentUser)
    {
        Stock? stock = await ReadStock();
        if (stock == null)
            return;

        int? quantity = MenuInput.ReadPositiveInteger("Enter Quantity To Buy: ");
        if (quantity == null)
            return;

        ShowPurchaseSummary(stock, quantity.Value);
        bool confirmed = MenuInput.ReadConfirmation("Confirm Buy:");
        if (!confirmed)
        {
            Console.WriteLine("Purchase cancelled.");
            return;
        }

        bool completed = await tradingService.Buy(currentUser, stock, quantity.Value);
        if (completed)
            Console.WriteLine("Purchase Completed Successfully");
        else
            Console.WriteLine("You Don't Have Enough Money");
    }
    private async Task<Stock?> ReadStock()
    {
        Console.Write("Enter Stock Symbol: ");
        string? symbol = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(symbol))
        {
            Console.WriteLine("Invalid stock symbol.");
            return null;
        }

        Stock? stock = await stockService.GetStock(symbol);

        if (stock == null)
        {
            Console.WriteLine($"{symbol} Doesn't Exist");
            return null;
        }

        Console.WriteLine($"Stock Current Price: {stock.price}");

        return stock;
    }
    private void ShowPurchaseSummary(Stock stock, int quantity)
    {
        Console.WriteLine(
            $"Total Cost of {quantity} shares of {stock.Symbol}: " +
            $"{quantity * stock.price:F2}");
    }
    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Trade =====");
        Console.WriteLine("1. Buy");
        Console.WriteLine("2. Sell");
        Console.WriteLine("3. Back");
    }
}