using Stockastic.Domain.Entities;
using Stockastic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.UI
{
    public class TradingMenu
    {
        public void Show(User currentUser)
        {
            StockService stockService = new StockService();
            PortfolioService portfolioService = new PortfolioService(currentUser);
            int op2 = 0;
            while (op2 != 5)
            {
                op2 = UserService.displayTradingService();
                switch (op2)
                {
                    case 1:
                        portfolioService.DisplayUserStocks();
                        break;
                    case 2:
                        stockService.DisplayAvailableStocks();
                        break;
                    case 3:
                        var (symbol, quantity) = portfolioService.GetStockOrder();
                        portfolioService.BuyStocks(symbol, quantity);
                        break;
                    case 4:
                        var (symboll, quantityy) = portfolioService.GetStockOrder();
                        portfolioService.SellStocks(symboll, quantityy);
                        break;
                }
            }
        }
    }
}
