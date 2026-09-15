using Stockastic.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Services
{
    public class TradingService(ApplicationDbContext context)
    {
        //private readonly List<Stock> stocks;
        //public TradingService()
        //{
        //    stocks = new List<Stock>
        //{
        //    new Stock
        //    {
        //        Symbol = "BTFH",
        //        Name = "Beltone Holding",
        //        Price = 3.10m
        //    },
        //    new Stock
        //    {
        //        Symbol = "ORHD",
        //        Name = "Orascom Development",
        //        Price = 39m
        //    },
        //    new Stock
        //    {
        //        Symbol = "EGAL",
        //        Name = "Egypt Aluminum",
        //        Price = 305m
        //    },
        //    new Stock
        //    {
        //        Symbol = "NVDA",
        //        Name = "NVIDIA",
        //        Price = 170.25m
        //    },
        //    new Stock
        //    {
        //        Symbol = "TSLA",
        //        Name = "Tesla",
        //        Price = 320.80m
        //    },
        //    new Stock
        //    {
        //        Symbol = "META",
        //        Name = "Meta",
        //        Price = 720.40m
        //    }
        //};
        //}

        //public List<Stock> GetStocks()
        //{
        //    return stocks;
        //}

        //public Stock? FindStock(string symbol)
        //{
        //    return stocks.FirstOrDefault(s =>
        //        s.Symbol.Equals(symbol, StringComparison.OrdinalIgnoreCase));
        //}

        //public void DisplayAvailableStocks()
        //{
        //    Console.WriteLine("Available Stocks");
        //    Console.WriteLine("------------------------------------------------");
        //    Console.WriteLine($"{"Symbol",-10} {"Name",-25} {"Price",10}");
        //    Console.WriteLine("------------------------------------------------");

        //    foreach (var x in GetStocks())
        //    {
        //        Console.WriteLine($"{x.Symbol,-10} {x.Name,-25} ${x.Price,9:F2}");
        //    }
        //}

        //public decimal GetPrice(string symbol)
        //{
        //    Stock stock = FindStock(symbol);
        //    return stock.Price;
        //}
    }
}
