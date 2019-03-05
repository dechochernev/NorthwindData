using BusinessLayer.Access.Queries;
using BusinessLayer.Models;
using BusinessLayer.Usecases.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Usecases
{
    public class GetMostExpensiveProducts : IGetMostExpensiveProducts
    {
        private readonly IGetMostExpensiveProductsQuery handlers;

        public GetMostExpensiveProducts(IGetMostExpensiveProductsQuery handlers)
        {
            this.handlers = handlers;
        }
        public async Task<IEnumerable<Product>> GetMostExpensiveProductsAsync()
        {
            var products = await handlers.HandleAsync();
            return products;
        }
    }
}
