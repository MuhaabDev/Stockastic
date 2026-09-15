using Stockastic.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Services
{
    public class PortfolioService
    {
        User currentUser;
        StockService StockService = new StockService();
        public PortfolioService(User user)
        {
            currentUser = user;
        }

        public void DisplayUserStocks()
        {
            Console.WriteLine("User Stocks");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(
                $"{"Symbol",-10} {"Name",-25} {"Qty",8} {"Avg Price",12} {"Total Cost",15}");
            Console.WriteLine("----------------------------------------------------------------------------");

            if (currentUser.portfolio.Holdings.Count == 0)
            {
                Console.WriteLine("Portfolio is empty.");
                return;
            }

            foreach (var holding in currentUser.portfolio.Holdings)
            {
                if (holding.Quantiy > 0)
                {
                    Console.WriteLine(
                        $"{holding.stock.Symbol,-10} " +
                        $"{holding.stock.Name,-25} " +
                        $"{holding.Quantiy,8} " +
                        $"${holding.AverageBuyPrice,11:F2} " +
                        $"${holding.Quantiy * holding.AverageBuyPrice,14:F2}");
                }
            }

            Console.WriteLine("----------------------------------------------------------------------------");
        }

        public (string Symbol, int Quantity) GetStockOrder()
        {
            Console.Write("Enter Stock Symbol: ");
            string symbol = Console.ReadLine()!.Trim().ToUpper();

            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine()!);

            return (symbol, quantity);
        }

        public StockHolding? findUserStock(string symbol)
        {
            StockHolding stock = null;
            foreach (var s in currentUser.portfolio.Holdings)
            {
                if (symbol == s.stock.Symbol)
                {
                    stock = s;
                }
            }
            return stock;

        }

        public void BuyStocks(string symbol, int quantity)
        {
            Stock stock = StockService.FindStock(symbol);
            if (stock != null)
            {
                if (stock.Price * quantity <= currentUser.portfolio.cash)
                {
                    StockHolding stockHolding = new StockHolding();
                    stockHolding.stock = stock;
                    stockHolding.Quantiy += quantity;
                    stockHolding.AverageBuyPrice = stock.Price;
                    currentUser.portfolio.Holdings.Add(stockHolding);
                    currentUser.portfolio.cash -= quantity * stock.Price;
                    Console.WriteLine($"Bought {quantity} of {symbol} Successfully , Cash Left : ${currentUser.portfolio.cash}");
                }
                else
                {
                    Console.WriteLine($"You Don't Have Enough Money");
                }
            }
            else
            {
                Console.WriteLine("Stock Doesn't Exist");
            }
        }

        public void SellStocks(string symbol, int quantity)
        {
            StockHolding stockHolding = findUserStock(symbol);
            if (stockHolding != null)
            {
                if (quantity <= stockHolding.Quantiy)
                {
                    stockHolding.Quantiy -= quantity;
                    currentUser.portfolio.cash += quantity * stockHolding.stock.Price;
                    Console.WriteLine($"{quantity} of {stockHolding.stock.Symbol} sold Successfully , Got {stockHolding.Quantiy} left");
                }
                else
                {
                    Console.WriteLine($"Failed , You only Got {stockHolding.Quantiy}");
                }
            }
            else
            {
                Console.WriteLine("Stock Doesn't Exist");
            }
        }
    }
}
