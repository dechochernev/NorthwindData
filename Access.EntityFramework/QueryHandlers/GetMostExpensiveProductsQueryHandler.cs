using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Access.EntityFramework.Models;
using BusinessLayer.Access.Queries;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Access.EntityFramework.QueryHandlers
{
    public class GetMostExpensiveProductsQueryHandler : IGetMostExpensiveProductsQuery
    {
        private readonly NorthwindContext northwindContext;

        public GetMostExpensiveProductsQueryHandler(NorthwindContext northwindContext)
        {
            this.northwindContext = northwindContext;
        }

        public async Task<IEnumerable<Product>> HandleAsync()
        {
            using (var context = northwindContext)
            {
                var products = await context.Products.FromSql("EXEC [dbo].[Ten Most Expensive Products]").ToListAsync();

                return Transform(products);
            }
        }

        private IEnumerable<Product> Transform(List<Products> products)
        {
            foreach (var product in products)
            {
                yield return new Product
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice
                };
            }
        }
    }
}
