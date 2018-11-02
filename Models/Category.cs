using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CatId { get; set; }
        public string CatName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
