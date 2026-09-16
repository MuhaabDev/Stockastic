using Stockastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StockId { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        // Navigation
        public User User { get; set; } = null!;
        public Stock Stock { get; set; } = null!;
    }
}
