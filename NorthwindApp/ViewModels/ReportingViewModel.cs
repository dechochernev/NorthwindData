using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindApp.ViewModels
{
    public class ReportingViewModel
    {
        public IEnumerable<Product> MostExpensiveProducts { get; set; }
    }
}
