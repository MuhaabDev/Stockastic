using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Sector {  get; set; } = string.Empty;
    }
}
