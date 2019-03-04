using BusinessLayer.Access.Queries;
using BusinessLayer.Models;
using BusinessLayer.Usecases.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Usecases
{
    public class GetAllRegions : IGetAllRegions
    {
        private readonly IGetAllRegionsQuery handlers;

        public GetAllRegions(IGetAllRegionsQuery handlers)
        {
            this.handlers = handlers;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            var regions =await handlers.HandleAsync();
            return regions;
        }
    }
}
