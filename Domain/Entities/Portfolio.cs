using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class Portfolio
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public decimal CashBalance { get; set; } = 0m;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation
        public User User { get; set; } = null!;
        public ICollection<Holding> Holdings { get; set; }
             = new List<Holding>();
    }
}
