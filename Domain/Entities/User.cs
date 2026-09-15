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
        public string CreatedAt { get; set; } = string.Empty;
       
        // Navigation portfolio
    }
}