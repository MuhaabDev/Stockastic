using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class Holding
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; } 
        public decimal AverageBuyPrice { get; set; }

        // Navigation
        public Portfolio Portfolio { get; set; } = null!;
        public Stock Stock { get; set; } = null!;
    }
}
