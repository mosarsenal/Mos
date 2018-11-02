using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProDescription { get; set; }
        public string ProPrice { get; set; }
        public string ProUnitPerPrice { get; set; }
        public string ProQty { get; set; }
        public int? CatId { get; set; }
        public int? UnitId { get; set; }
        public string Pro_Status { get; set; }

        public Category Cat { get; set; }
        public Unit Unit { get; set; }
    }
}
