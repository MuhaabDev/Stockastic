using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Domain.Entities
{
    public class Portfolio
    {
        public int id;
        // user id foriegn
        public decimal Cash = decimal.Zero;
        public string CreatedAt { get; set; } = string.Empty;
        
        // navigation user , holdings
    }
}
