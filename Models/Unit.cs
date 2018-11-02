using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Product = new HashSet<Product>();
        }

        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
