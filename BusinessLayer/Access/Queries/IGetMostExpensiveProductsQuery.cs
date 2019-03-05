using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Access.Queries
{
    public interface IGetMostExpensiveProductsQuery
    {
        Task<IEnumerable<Product>> HandleAsync();
    }
}
