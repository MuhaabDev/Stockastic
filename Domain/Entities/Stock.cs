using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Sector {  get; set; } = string.Empty;
        public string Industry {  get; set; } = string.Empty;
        public decimal price { get; set; } 

        // Navigation
        public ICollection<Holding> Holdings { get; set; } = new List<Holding>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<WatchlistItem> WatchlistItems { get; set; } = new List<WatchlistItem>();           
    }
}