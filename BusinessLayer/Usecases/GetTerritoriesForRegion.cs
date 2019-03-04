using BusinessLayer.Access.Queries;
using BusinessLayer.Models;
using BusinessLayer.Usecases.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Usecases
{
    public class GetTerritoriesForRegion : IGetTerritoriesForRegion
    {
        private readonly IGetTerritoriesForRegionQuery handlers;

        public GetTerritoriesForRegion(IGetTerritoriesForRegionQuery handlers)
        {
            this.handlers = handlers;
        }

        public async Task<IEnumerable<Territory>> GetTerritoriesForRegionAsync(int regionId)
        {
            var territories = await handlers.HandleAsync(new GetTerritoriesForRegionQuery(regionId));
            return territories;
        }
    }
}
