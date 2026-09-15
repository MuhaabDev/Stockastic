using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class Holding
    {
        public int Id { get; set; }
        // FK portfolio_id
        // FK Stock_id
        public int Quantity { get; set; } 
        public decimal AverageBuyPrice { get; set; }

        // Navigation : Portfolio , Stock
    }
}
