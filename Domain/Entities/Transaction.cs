using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Timestamp { get; set; }
        // FK : user_id / portfolio_id , stock_id
    }
}
