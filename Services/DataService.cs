using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Stockastic.Services
{
    public class DataService
    {
        private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "Data", "users.json");
        public void SaveUsers()
        {
            
        }

        public List<User> LoadUsers()
        {
            
        }
    }
}
