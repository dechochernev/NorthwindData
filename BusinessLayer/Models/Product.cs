using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
