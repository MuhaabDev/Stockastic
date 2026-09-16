using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ConsoleColor SelectedColor { get; set; } = ConsoleColor.White;
        // Navigation
        public Portfolio? Portfolio { get; set; }
        public ICollection<Transaction> Transactions { get; set; } =
                new List<Transaction>();
    }
}